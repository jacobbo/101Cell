using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    public class MainWindowViewModel : NotifyPropertyChangedBase, IDisposable
    {
        
        List<Subject<RowModel>> _subjects = new List<Subject<RowModel>>();
        IDisposable _token;       

        public MainWindowViewModel()
        {
            Random _random = new Random();

            TableViewModel1 = new TableViewModel(61, 30);

            TableViewModel2 = new TableViewModel(61, 10);

            var dataService = new CellDataService
            {
                ColumnCount = 61,
                RowCount = 50
            };

            //var data = dataService.GetData(TimeSpan.FromMilliseconds(500));
            var interval = Observable.Interval(TimeSpan.FromMilliseconds(500));

            _token = interval.ObserveOn(TaskPoolScheduler.Default)
                .Subscribe((d) => 
                {
                    //foreach (var cellData in d)
                    {
                        foreach (var column in TableViewModel1.Columns.OfType<ColumnViewModel>())
                        {
                            //bool found = false;
                            foreach (var cell in column.Rows.OfType<CellViewModel>())
                            {
                                //if (cell.Column == cellData.Column &&
                                //    cell.Row == cellData.Row)
                                {
                                    cell.Text = _random.Next(1, 3).ToString();
                                    //found = true;
                                    //break;
                                }
                            }

                            //if (found)
                            //{
                            //    break;
                            //}
                        }

                        foreach (var column in TableViewModel2.Columns.OfType<ColumnViewModel>())
                        {
                            //bool found = false;
                            foreach (var cell in column.Rows.OfType<CellViewModel>())
                            {
                                //if (cell.Column == cellData.Column &&
                                //    cell.Row == cellData.Row)
                                {
                                    cell.Text = _random.Next(1, 3).ToString();
                                    //found = true;
                                    //break;
                                }
                            }

                            //if (found)
                            //{
                            //    break;
                            //}
                        }
                    }
                });

            //_token = Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(_ =>
            //{
            //    foreach (var s in _subjects)
            //    {
            //        var row = new RowModel
            //        {
            //            Value1 = _random.NextDouble(),
            //            Value2 = _random.NextDouble(),
            //            Value3 = _random.NextDouble(),
            //            Value4 = _random.NextDouble(),
            //            Value5 = _random.NextDouble(),
            //            Value6 = _random.NextDouble(),
            //            Value7 = _random.NextDouble(),
            //            Value8 = _random.NextDouble(),
            //            Value9 = _random.NextDouble(),
            //            Value10 = _random.NextDouble(),
            //            Value11 = _random.NextDouble(),
            //            Value12 = _random.NextDouble(),
            //        };

            //        s.OnNext(row);
            //    }
            //});
        }

        private TableViewModel _tableViewModel1;
        public TableViewModel TableViewModel1
        {
            get { return _tableViewModel1; }
            set { SetField(ref _tableViewModel1, value); }
        }

        private TableViewModel _tableViewModel2;
        public TableViewModel TableViewModel2
        {
            get { return _tableViewModel2; }
            set { SetField(ref _tableViewModel2, value); }
        }

        public void Dispose()
        {
            //foreach (var d in Rows.OfType<IDisposable>())
            //{
            //    d.Dispose();
            //}

            _token.Dispose();
        }
    }
}
