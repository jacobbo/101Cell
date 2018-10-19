using System.Collections.ObjectModel;
using System.Linq;

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

        //public void RaisePropertyChanged()
        //{
        //    foreach (var row in Rows.OfType<CellViewModel>())
        //    {
        //        row.RaisePropertyChanged();
        //    }
        //}
    }
}
