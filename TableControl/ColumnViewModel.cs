using System.Collections.ObjectModel;

namespace WpfApp1
{
    public class ColumnViewModel : ColumnViewModelBase
    {        
        public ObservableCollection<CellViewModelBase> Rows { get; set; } = new ObservableCollection<CellViewModelBase>();

        public void SetFocus(int cellColumn, int cellRow)
        {
            foreach (var cell in Rows)
            {
                if (cellColumn == cell.Column && cellRow == cell.Row)
                {
                    cell.IsFocused = true;
                    break;
                }
            }
        }
    }
}
