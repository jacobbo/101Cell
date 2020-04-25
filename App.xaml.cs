using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new MainWindowViewModel();
            var window = new MainWindow
            {
                DataContext = viewModel
            };

            RenderOptions.SetEdgeMode(window, EdgeMode.Aliased);

            window.Closed += (s, a) => viewModel.Dispose();
            window.Show();
        }
    }
}
