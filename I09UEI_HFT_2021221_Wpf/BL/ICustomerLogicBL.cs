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
        bool AddCustomer(CustomerVM list,ref int id);

        
        bool ModCustomer(CustomerVM customerToModify);


        bool DelCustomer(int customerId);

      
        public IList<CustomerVM> GetCustomers();

        int GetCustomerCount();
    }
}
