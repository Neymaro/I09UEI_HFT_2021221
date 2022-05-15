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
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        private ICustomerLogicBL logic;
        public CreateCustomer()
        {

            InitializeComponent();
            this.logic = new CustomerLogicBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerVM customerData = new CustomerVM()
            {
                Name = Name.Text,
                Phone= Convert.ToInt32(Phone.Text),
                TravelAgencyId= Convert.ToInt32(TravelAgencyId.Text)
            };
            int id = 0;
            bool result = this.logic.AddCustomer(customerData,ref id);
            if(result)
            {
                MessageBox.Show("Customer Created Successfully with ID : "+id);
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
