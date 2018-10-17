using System.Collections.ObjectModel;
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
                ColumnViewModelBase column = null;
                if (i % 2 == 0)
                {
                    var column1 = new ColumnViewModel();
                    foreach (var j in Enumerable.Range(0, RowCount))
                    {
                        CellViewModelBase row = null;
                        if (j == 0)
                        {
                            row = new ColumnHeaderViewModel { Text = $"Column{i + 1}" };
                        }
                        else
                        {
                            row = new CellViewModel(column1) { Column = i, Row = j, Text = $"{{{i}, {j}}}" };
                        }

                        column1.Rows.Add(row);
                    }

                    column = column1;

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
                    column = new ColumnSplitterViewModel();
                }

                column.ColumnIndex = i;
                Columns.Add(column);
            }

            StarColumns = stringBuilder.ToString();
            SharedSizeGroups = stringBuilder2.ToString();
        }

        public ObservableCollection<ColumnViewModelBase> Columns { get; set; } =
            new ObservableCollection<ColumnViewModelBase>();

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

        private string _starColumns;
        public string StarColumns
        {
            get { return _starColumns; }
            set { SetField(ref _starColumns, value); }
        }

        private string _sharedSizeGroups;
        public string SharedSizeGroups
        {
            get { return _sharedSizeGroups; }
            set { SetField(ref _sharedSizeGroups, value); }
        }
    }
}
