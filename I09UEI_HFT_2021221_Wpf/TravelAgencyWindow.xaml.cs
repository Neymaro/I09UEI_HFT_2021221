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
    public partial class TravelAgencyWindow : Window
    {

        private ITravelAgencyLogicBL logic;
        public TravelAgencyWindow()
        {
            InitializeComponent();

            this.logic = new TravelAgencyLogicBL();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateTravelAgency cc = new CreateTravelAgency();
            cc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            DeleteTravelAgency dc = new DeleteTravelAgency();
            dc.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateTravelAgency uc = new UpdateTravelAgency();
            uc.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AllTravelAgencies ac = new AllTravelAgencies();
            ac.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.logic.GetTravelAgencyCount().ToString());
        }
    }
}
