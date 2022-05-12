using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.BL
{
    public interface ICustomerLogicBL
    {
        void AddCustomer(IList<CustomerVM> list);

        
        void ModCustomer(CustomerVM customerToModify);

       
        void DelCustomer(IList<CustomerVM> list, CustomerVM customer);

      
        public IList<CustomerVM> GetCustomers();
    }
}
