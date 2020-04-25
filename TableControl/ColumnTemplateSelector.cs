using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.TableControl;

namespace WpfApp1
{
    public class CellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RowSeparatorTemplate { get; set; }

        public DataTemplate ColumnSeparatorTemplate { get; set; }

        public DataTemplate ColumnSplitterTemplate { get; set; }

        public DataTemplate ColumnHeaderTemplate { get; set; }

        public DataTemplate CellTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ColumnSplitterViewModel)
            {
                return ColumnSplitterTemplate;
            }
            else if (item is RowSeparatorViewModel)
            {
                return RowSeparatorTemplate;
            }
            else if (item is ColumnSeparatorViewModel)
            {
                return ColumnSeparatorTemplate;
            }
            else if (item is ColumnHeaderViewModel)
            {
                return ColumnHeaderTemplate;
            }

            return CellTemplate;
        }
    }
}
