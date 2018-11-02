using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using WpfApp1.TableControl;

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
                        else if (j % 4 == 0)
                        {
                            cell = new SeparatorViewModel {ColumnSpan = ColumnCount};
                        }
                        else
                        {
                            cell = new CellViewModel(this) { Text = $"{{{i}, {j}}}" };
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

        private double _zoom = 1.5;
        public double Zoom
        {
            get { return _zoom; }
            set { SetField(ref _zoom, value); }
        }

        //private bool _isLayoutSuppressed;
        //public bool IsLayoutSuppressed
        //{
        //    get { return _isLayoutSuppressed; }
        //    set { SetField(ref _isLayoutSuppressed, value); }
        //}

        private string DefaultCellBackground = "White";

        public void SelectCell(int column, int row, bool isMultiSelection = false)
        {
            if (column < 0 || column >= ColumnCount || row < 0 || row >= RowCount)
            {
                return;
            }

            foreach (var cell in Cells.OfType<CellViewModel>())
            {
                if (cell.Column == column && cell.Row == row)
                {
                    cell.IsEditMode = true;
                    cell.IsFocused = true;
                    cell.IsSelected = true;
                    cell.IsHighlighted = false;
                }
                else if (cell.Row == row)
                {
                    cell.IsEditMode = false;
                    cell.IsFocused = false;
                    cell.IsSelected = cell.IsSelected && isMultiSelection;
                    cell.IsHighlighted = true;
                }
                else
                {
                    cell.IsEditMode = false;
                    cell.IsFocused = false;
                    cell.IsSelected = cell.IsSelected && isMultiSelection;
                    cell.IsHighlighted = cell.IsHighlighted && isMultiSelection;
                }
            }
        }

        public void SelectRectangularBlockOfCells(int column, int row)
        {
            if (column < 0 || column >= ColumnCount || row < 0 || row >= RowCount)
            {
                return;
            }

            int minColumn = column;
            int maxColumn = column;
            int minRow = row;
            int maxRow = row;

            foreach (var cell in Cells.OfType<CellViewModel>().Where(c => c.IsSelected))
            {
                minColumn = cell.Column < minColumn ? cell.Column : minColumn;
                maxColumn = cell.Column > maxColumn ? cell.Column : maxColumn;
                minRow = cell.Row < minRow ? cell.Row : minRow;
                maxRow = cell.Row > maxRow ? cell.Row : maxRow;
            }

            foreach (var cell in Cells.OfType<CellViewModel>())
            {
                if (cell.Row >= minRow && cell.Row <= maxRow)
                {
                    cell.IsHighlighted = true;

                    if (cell.Column >= minColumn && cell.Column <= maxColumn)
                    {
                        cell.IsSelected = true;

                        if (cell.Column == column && cell.Row == row)
                        {
                            cell.IsFocused = true;
                        }
                    }
                }
                
            }
        }

        //public void ClearFocus()
        //{
        //    foreach (var cell in Cells.OfType<CellViewModel>())
        //    {
        //        cell.IsFocused = false;
        //        cell.IsSelected = false;
        //    }
        //}



    }
}
