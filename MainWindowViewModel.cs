using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp1
{
    public class MainWindowViewModel : NotifyPropertyChangedBase, IDisposable
    {
        readonly Random _random = new Random();
        List<Subject<RowModel>> _subjects = new List<Subject<RowModel>>();
        readonly IDisposable _token;

        void UpdateGrid(/*IEnumerable<CellModel> data*/)
        {
            
            if (TableViewModel1 == null)
            {
                return;
            }
            //foreach (var i in Enumerable.Range(0, 10000))
            //{
            //    var s = _random.Next(1, 999).ToString().ToUpper();

            //}


                foreach (var cell in TableViewModel1.Cells
                        .OfType<CellViewModel>())
                {
                    //foreach (var cell in column.Rows.OfType<CellViewModel>())
                    {
                        //if (_random.Next(1, 11) % 4 == 0)
                        {
                            //cell.Text = _random.Next(1, 99).ToString();
                            //break;
                        }
                    }

                    //if (found)
                    //{
                    //    break;
                    //}
                }


                    //TableViewModel1.RaisePropertyChanged();



                //    foreach (var cell in TableViewModel2.Cells
                //        .OfType<CellViewModel>()
                //        .Where(c => c.Column == 31))
                //    {
                ////    bool found = false;
                ////    foreach (var cell in column.Rows.OfType<CellViewModel>())
                ////    {
                ////        //if (cell.Column == cellData.Column &&
                ////        //    cell.Row == cellData.Row)
                ////        {
                //            cell.Text = _random.Next(1, 3).ToString();
                ////            found = true;
                ////            //break;
                ////        }
                ////    }

                ////    //if (found)
                ////    //{
                ////    //    break;
                ////    //}
                //}

                    //TableViewModel2.RaisePropertyChanged();

        }

        public MainWindowViewModel()
        {
            

            //TableViewModel1 = new TableViewModel(11, 10);

            TableViewModel2 = new TableViewModel(21, 10);

            RefreshCommand = new RelayCommand(o =>
            {
                IsLoading = true;

                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    TableViewModel1 = new TableViewModel(31, 61);
                    TableViewModel1.IsLayoutSuppressed = false;
                }, DispatcherPriority.ContextIdle);                

                Dispatcher.CurrentDispatcher.Invoke(() => 
                {
                    IsLoading = false;
                }, DispatcherPriority.ContextIdle);
            });

            //var dataService = new CellDataService
            //{
            //    ColumnCount = 101,
            //    RowCount = 50
            //};

            //var data = dataService.GetData(TimeSpan.FromMilliseconds(500));
            var interval = Observable.Interval(TimeSpan.FromMilliseconds(1000));

            _token = interval//.ObserveOn(TaskPoolScheduler.Default)
                .Subscribe((l) => UpdateGrid());

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

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetField(ref _isLoading, value); }
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

        public ICommand RefreshCommand { get; }

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
