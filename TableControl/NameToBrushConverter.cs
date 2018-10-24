using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp1.TableControl
{
    public class NameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var brush = Brushes.Red;

            var brushName = value as string;
            if (brushName != null)
            {
                var properties = typeof(Brushes).GetProperties(BindingFlags.Static | BindingFlags.Public);
                var property = properties.FirstOrDefault(p => p.Name == brushName);
                if (property != null)
                {
                    brush = (SolidColorBrush)property.GetValue(null, null);
                }
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
