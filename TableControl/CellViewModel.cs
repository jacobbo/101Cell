using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.ColorDialog;
using WpfApp1.TableControl;

namespace WpfApp1
{
    public class CellViewModel : CellViewModelBase
    {
        private TableViewModel _tableViewModel;

        public CellViewModel(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;

            UpCommand = new RelayCommand(o =>
            {
                _tableViewModel.SelectCell(Column, Row - 1);
            });

            DownCommand = new RelayCommand(o =>
            {
                _tableViewModel.SelectCell(Column, Row + 1);
            });

            RightCommand = new RelayCommand(o =>
            {
                _tableViewModel.SelectCell(Column + 2, Row);
            });

            LeftCommand = new RelayCommand(o =>
            {
                _tableViewModel.SelectCell(Column - 2, Row);
            });

            SelectCellCommand = new RelayCommand(o =>
            {
                _tableViewModel.SelectCell(Column, Row);
            });

            SelectNonAdjacentCellsCommand = new RelayCommand(o =>
            {
                _tableViewModel.SelectCell(Column, Row, true);
            });

            SelectRectangularBlockOfCellsCommand = new RelayCommand(o =>
            {
                _tableViewModel.SelectRectangularBlockOfCells(Column, Row);
            });

            Actions.Add(new ContextActionViewModel
            {
                Name = "Background...",
                Action = new RelayCommand(o =>
                {
                    var viewModel = new ColorDialogViewModel();
                    var colorDialog = new ColorDialog.ColorDialog
                    {
                        DataContext = viewModel
                    };

                    colorDialog.ShowDialog();
                    if (viewModel.SelectedColor != null)
                    {
                        Background = viewModel.SelectedColor.Name;
                    }
                })
            });

            Actions.Add(new ContextActionViewModel
            {
                Name = "Copy",
                Action = new RelayCommand(o =>
                {
                    Clipboard.SetDataObject(Text);
                })
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

        private bool _isValueStale;
        public bool IsValueStale
        {
            get { return _isValueStale; }
            set { SetField(ref _isValueStale, value); }
        }

        private bool _isHighlighted;
        public bool IsHighlighted
        {
            get { return _isHighlighted; }
            set { SetField(ref _isHighlighted, value); }
        }

        public ICommand UpCommand { get; }

        public ICommand DownCommand { get; }

        public ICommand RightCommand { get; }

        public ICommand LeftCommand { get; }

        public ICommand SelectCellCommand { get; }

        public ICommand SelectNonAdjacentCellsCommand { get; }

        public ICommand SelectRectangularBlockOfCellsCommand { get; }

        public ObservableCollection<ContextActionViewModel> Actions { get; } =
            new ObservableCollection<ContextActionViewModel>();

        private string _background = "White";
        public string Background
        {
            get { return _background; }
            set { SetField(ref _background, value); }
        }
    }
}
