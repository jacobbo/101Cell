using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.TableControl
{
    partial class TableResourceDictionary : ResourceDictionary
    {
        public TableResourceDictionary()
        {
            InitializeComponent();
        }

        private void HandleLayoutUpdated(object sender, EventArgs e)
        {
            var g = (Grid)sender;
            
        }
    }
}
