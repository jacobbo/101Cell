using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WpfApp1
{
    public class TableViewModel : NotifyPropertyChangedBase
    {
        public TableViewModel(int columns = 101, int rows = 100)
        {
            ColumnCount = columns;
            RowCount = rows;

            var stringBuilder = new StringBuilder();
            var stringBuilder2 = new StringBuilder();
            foreach (var i in Enumerable.Range(0, ColumnCount))
            {
                //CellViewModelBase cell = null;
                if (i % 2 == 0)
                {
                    //var column1 = new ColumnViewModel();
                    foreach (var j in Enumerable.Range(0, RowCount))
                    {
                        CellViewModelBase cell;
                        if (j == 0)
                        {
                            cell = new ColumnHeaderViewModel { Text = $"Column{i + 1}" };
                        }
                        else
                        {
                            cell = new CellViewModel(this) { Column = i, Row = j, Text = $"{{{i}, {j}}}" };
                        }

                        cell.Column = i;
                        cell.Row = j;

                        Cells.Add(cell);
                    }

                    //column = column1;

                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(',');
                    }

                    //if (i>0)
                    //stringBuilder.Append(i.ToString());

                    stringBuilder2.Append($"G{i}:{i};");
                }
                else
                {
                    var cell = new ColumnSplitterViewModel
                    {
                        Column = i,
                        RowSpan = RowCount,
                        Row = 0
                    };
                    Cells.Add(cell);

                }
            }

            //StarColumns = stringBuilder.ToString();
            SharedSizeGroups = stringBuilder2.ToString();
        }

        private bool _isVisible = true;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetField(ref _isVisible, value); }
        }

        //public ObservableCollection<ColumnViewModelBase> Columns { get; set; } =
        //    new ObservableCollection<ColumnViewModelBase>();

        public ObservableCollection<CellViewModelBase> Cells { get; set; } =
            new ObservableCollection<CellViewModelBase>();

        private int _columnCount;
        public int ColumnCount
        {
            get { return _columnCount; }
            set { SetField(ref _columnCount, value); }
        }

        private int _rowCount;
        public int RowCount
        {
            get { return _rowCount; }
            set { SetField(ref _rowCount, value); }
        }

        private string _starColumns = string.Empty;
        public string StarColumns
        {
            get { return _starColumns; }
            set { SetField(ref _starColumns, value); }
        }

        private string _starRows = string.Empty;
        public string StarRows
        {
            get { return _starRows; }
            set { SetField(ref _starRows, value); }
        }

        private string _sharedSizeGroups;
        public string SharedSizeGroups
        {
            get { return _sharedSizeGroups; }
            set { SetField(ref _sharedSizeGroups, value); }
        }

        private double _zoom = 0.5;
        public double Zoom
        {
            get { return _zoom; }
            set { SetField(ref _zoom, value); }
        }

        //public void RaisePropertyChanged()
        //{
        //    foreach (var column in Columns.OfType<ColumnViewModel>())
        //    {
        //        column.RaisePropertyChanged();
        //    }
        //}
    }
}
