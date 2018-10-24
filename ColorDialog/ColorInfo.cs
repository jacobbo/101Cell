using System.Windows.Media;

namespace WpfApp1.ColorDialog
{
    public class ColorInfo
    {
        public string Name { get; set; }
        public Brush Brush { get; set; }

        public ColorInfo(string name, Brush brush)
        {
            Name = name;
            Brush = brush;
        }
    }
}
