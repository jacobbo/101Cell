using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace WpfApp1
{
    public class CellDataService
    {
        Random _random = new Random();

        public int ColumnCount { get; set; }

        public int RowCount { get; set; }

        public IObservable<IEnumerable<CellModel>> GetData(TimeSpan interval)
        {
            return Observable.Create<IEnumerable<CellModel>>(observer =>
            {
                return TaskPoolScheduler.Default.ScheduleAsync(async (ctrl, ct) =>
                {
                    var watch = new Stopwatch();

                    for (; ; )
                    {
                        if (ct.IsCancellationRequested)
                        {
                            break;
                        }

                        watch.Restart();

                        try
                        {
                            var data = GetDataInternal();
                            observer.OnNext(data);
                        }
                        catch (Exception ex)
                        {
                             observer.OnError(ex);
                            throw;
                        }

                        watch.Stop();

                        var diff = interval - watch.Elapsed;
                        if (diff > TimeSpan.Zero)
                        {
                            await ctrl.Sleep(diff).ConfigureAwait(false);
                        }
                    }
                });
            });
        }

        public IEnumerable<CellModel> GetDataInternal()
        {
            var cells = new List<CellModel>();
            for (var i = 0; i < ColumnCount; i += 2)
            {
                foreach (var j in Enumerable.Range(0, RowCount))
                {
                    var cell = new CellModel
                    {
                        Column = i,
                        Row = j,
                        Text = _random.Next(1, 100).ToString()
                    };
                    cells.Add(cell);
                }
            }

            return cells;
        }
    }
}
