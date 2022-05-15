using I09UEI_HFT_2021221_Wpf.BL;
using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace I09UEI_HFT_2021221_Wpf.UI
{
    /// <summary>
    /// Interaction logic for AllCustomers.xaml
    /// </summary>
    public partial class AllTravelAgencies : Window
    {
        public List<TravelAgencyVM> TravelAgencyList { get; set; }
        private ITravelAgencyLogicBL logic;
        public AllTravelAgencies()
        {
            InitializeComponent();
            this.logic = new TravelAgencyLogicBL();
            TravelAgencyList = new List<TravelAgencyVM>();
            if (this.logic != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (TravelAgencyVM customer in this.logic.GetTravelAgencies())
                {
                    TravelAgencyList.Add(customer);

                }
                lstBox.ItemsSource = TravelAgencyList;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
