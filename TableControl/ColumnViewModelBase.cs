using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ColumnViewModelBase : NotifyPropertyChangedBase
    {
        private int _columnIndex;
        public int ColumnIndex
        {
            get { return _columnIndex; }
            set { SetField(ref _columnIndex, value); }
        }
    }
}
