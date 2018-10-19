namespace WpfApp1
{
    public class CellViewModelBase : NotifyPropertyChangedBase
    {
        public int Column { get; set; }

        public int ColumnSpan { get; set; } = 1;

        public int Row { get; set; }

        public int RowSpan { get; set; } = 1;

        private bool _isFocused;
        public bool IsFocused
        {
            get { return _isFocused; }
            set { SetField(ref _isFocused, value); }
        }
    }
}
