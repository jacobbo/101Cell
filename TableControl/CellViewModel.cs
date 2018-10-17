using System.Windows.Input;

namespace WpfApp1
{
    public class CellViewModel : CellViewModelBase
    {
        private ColumnViewModel _columnViewModel;

        public CellViewModel(ColumnViewModel columnViewModel)
        {
            _columnViewModel = columnViewModel;

            UpCommand = new RelayCommand((o) =>
            {
                IsFocused = false;
                _columnViewModel.SetFocus(Column, Row - 1);
            });

            DownCommand = new RelayCommand((o) =>
            {
                IsFocused = false;
                _columnViewModel.SetFocus(Column, Row + 1);
            });
        }

        private string _value;
        public string Text
        {
            get { return _value; }
            set
            {
                int curr;
                int newVal;

                if (int.TryParse(_value, out curr) && int.TryParse(value, out newVal))
                {
                    IsUp = newVal > curr;
                    IsDown = curr > newVal;
                }

                SetField(ref _value, value);        
            }
        }

        private bool _isUp;
        public bool IsUp
        {
            get { return _isUp; }
            set { SetField(ref _isUp, value); }
        }

        private bool _isDown;
        public bool IsDown
        {
            get { return _isDown; }
            set { SetField(ref _isDown, value); }
        }

        public ICommand UpCommand { get; }

        public ICommand DownCommand { get; }
    }
}
