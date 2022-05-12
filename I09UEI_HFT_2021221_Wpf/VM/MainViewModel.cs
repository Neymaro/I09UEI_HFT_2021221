using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using I09UEI_HFT_2021221_Wpf.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace I09UEI_HFT_2021221_Wpf.VM
{
    public class MainViewModel : ViewModelBase
    {
        private ICustomerLogicBL logic;
        private CustomerVM customerSelected;

        public CustomerVM CustomerSelected { get => this.customerSelected; set => this.Set(ref this.customerSelected, value); }

        public ObservableCollection<CustomerVM> Customer { get; private set; }

        public ICommand AddCmd { get; private set; }

        public ICommand DelCmd { get; private set; }

        public ICommand ModCmd { get; private set; }


        public MainViewModel(ICustomerLogicBL logicBL)
        {
            this.logic = logicBL;
            this.Customer = new ObservableCollection<CustomerVM>();

            if (this.logic != null)
            {
                foreach (CustomerVM customer in this.logic.GetCustomers())
                {
                    this.Customer.Add(customer);
                }
            }

            if (this.IsInDesignMode)
            {
                CustomerVM c1 = new CustomerVM() { Name = "Hamza 1" };
                CustomerVM c2 = new CustomerVM() { Name = "Hamza 2", Phone = 5555555 };
                this.Customer.Add(c1);
                this.Customer.Add(c2);
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddCustomer(this.Customer));
            this.ModCmd = new RelayCommand(() => this.logic.ModCustomer(this.CustomerSelected));
            this.DelCmd = new RelayCommand(() => this.logic.DelCustomer(this.Customer, this.customerSelected));
        }
        //public MainViewModel()
        //    : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ICustomerLogicBL>())
        //{
        //}
        public MainViewModel()
        {
            

        }
    }
}

