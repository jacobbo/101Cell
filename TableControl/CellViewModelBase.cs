namespace WpfApp1
{
    public class CellViewModelBase : NotifyPropertyChangedBase
    {
        public int Column { get; set; }

        public int Row { get; set; }

        private bool _isFocused;
        public bool IsFocused
        {
            get { return _isFocused; }
            set { SetField(ref _isFocused, value); }
        }
    }
}
