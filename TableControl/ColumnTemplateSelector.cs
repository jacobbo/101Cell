using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class ColumnTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ColumnSplitterTemplate { get; set; }

        public DataTemplate ColumnTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ColumnSplitterViewModel)
            {
                return ColumnSplitterTemplate;
            }

            return ColumnTemplate;
        }
    }
}
