using GalaSoft.MvvmLight.Command;
using I09UEI_HFT_2021221_Wpf.BL;
using I09UEI_HFT_2021221_Wpf.UI;
using I09UEI_HFT_2021221_Wpf.VM;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace I09UEI_HFT_2021221_Wpf
{
    public partial class PackageWindow : Window
    {

        private IPackageLogicBL logic;
        public PackageWindow()
        {
            InitializeComponent();
            this.logic = new PackageLogicBL();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePackage cc = new CreatePackage();
            cc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            DeletePackage dc = new DeletePackage();
            dc.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdatePackage uc = new UpdatePackage();
            uc.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AllPackages ac = new AllPackages();
            ac.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.logic.GetPackageCount().ToString());
        }
    }
}
