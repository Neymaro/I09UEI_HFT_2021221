using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.VM
{
    class EditorViewModel : ViewModelBase
    {
        private CustomerVM customer;

    
        public CustomerVM Customer
        {
            get { return this.customer; }
            set { this.Set(ref this.customer, value); }
        }

        public EditorViewModel()
        {
            this.customer = new CustomerVM();
            if (this.IsInDesignMode)
            {
                this.customer.Id = 100;
                this.customer.Name = "Hamza Unsal";
            }
        }
    }
}
