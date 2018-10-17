using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class RowTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ColumnHeaderTemplate { get; set; }

        public DataTemplate RowTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ColumnHeaderViewModel)
            {
                return ColumnHeaderTemplate;
            }

            return RowTemplate;
        }
    }
}
