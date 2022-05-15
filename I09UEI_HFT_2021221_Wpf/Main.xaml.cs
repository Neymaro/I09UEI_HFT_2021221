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

namespace I09UEI_HFT_2021221_Wpf
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow cs = new CustomerWindow();
            cs.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TravelAgencyWindow tw = new TravelAgencyWindow();
            tw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PackageWindow pw = new PackageWindow();
            pw.Show();
        }
    }
}
