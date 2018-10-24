using System.Windows.Input;

namespace WpfApp1.TableControl
{
    public class ContextActionViewModel : NotifyPropertyChangedBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }

        public ICommand Action { get; set; }
    }
}
