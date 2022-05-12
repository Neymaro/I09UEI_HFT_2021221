using Autofac;
using I09UEI_HFT_2021221_Wpf.Startup;
using System.Windows;

namespace I09UEI_HFT_2021221_Wpf
{
    /// <summary
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }



}
