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
    public partial class DeleteCustomer : Window
    {
        private ICustomerLogicBL logic;
        public DeleteCustomer()
        {

            InitializeComponent();
            this.logic = new CustomerLogicBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = this.logic.DelCustomer(Convert.ToInt32(Id.Text));
            if(result)
            {
                MessageBox.Show("Customer Deleted Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Customer doesnot exist");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
