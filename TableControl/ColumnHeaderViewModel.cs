namespace WpfApp1
{
    public class ColumnHeaderViewModel : CellViewModelBase
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetField(ref _text, value); }
        }
    }
}
