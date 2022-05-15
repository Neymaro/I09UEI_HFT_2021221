using I09UEI_HFT_2021221_Wpf.BL;
using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AllCustomers : Window
    {
        public List<CustomerVM> CustomerList { get; set; }
        private ICustomerLogicBL logic;
        public AllCustomers()
        {
            InitializeComponent();
            this.logic = new CustomerLogicBL();
            CustomerList = new List<CustomerVM>();
            if (this.logic != null)
            {


                StringBuilder sb = new StringBuilder();
                foreach (CustomerVM customer in this.logic.GetCustomers())
                {
                    CustomerList.Add(customer);
                    //sb.Append($"Customer Name: {customer.Name}\nCustomer Phone: {customer.Phone}\nTravel Agency Id: {customer.TravelAgencyId}\n\n");
                }
                //txt1.Text = sb.ToString();
                lstBox.ItemsSource = CustomerList;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
