using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1.ColorDialog
{
    public class ColorDialogViewModel : NotifyPropertyChangedBase
    {
        public ColorDialogViewModel()
        {
            var properties = typeof(Brushes).GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (var property in properties)
            {
                var colorInfo = new ColorInfo(property.Name,
                    (SolidColorBrush)property.GetValue(null, null));
                AllColors.Add(colorInfo);
            }

            SelectColorCommand = new RelayCommand(o =>
            {
                //_tableViewModel.SelectRectangularBlockOfCells(Column, Row);
            }, p => SelectedColor != null);
        }

        public ObservableCollection<ColorInfo> AllColors { get; set; }
            = new ObservableCollection<ColorInfo>();

        private ColorInfo _selectedColor;

        public ColorInfo SelectedColor
        {
            get { return _selectedColor; }
            set { SetField(ref _selectedColor, value); }
        }

        public ICommand SelectColorCommand { get; }
    }
}
