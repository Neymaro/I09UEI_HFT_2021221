using I09UEI_HFT_2021221_Wpf.VM;
using System.Windows;

namespace I09UEI_HFT_2021221_Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainView)
        {
            InitializeComponent();
            DataContext = mainView;
        }
    }
}
