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
    public partial class CustomerWindow : Window
    {

        private ICustomerLogicBL logic;
        public CustomerWindow()
        {
            InitializeComponent();
            this.logic = new CustomerLogicBL();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomer cc = new CreateCustomer();
            cc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            DeleteCustomer dc = new DeleteCustomer();
            dc.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateCustomer uc = new UpdateCustomer();
            uc.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AllCustomers ac = new AllCustomers();
            ac.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.logic.GetCustomerCount().ToString());
        }
    }
}
