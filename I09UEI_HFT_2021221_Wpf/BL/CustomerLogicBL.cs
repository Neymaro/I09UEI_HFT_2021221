using GalaSoft.MvvmLight.Messaging;
using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.BL
{
    public class CustomerLogicBL : ICustomerLogicBL
    {
        private IEditorService editorService;
        private IMessenger messengerService;
        private ICustomerLogic logic;
        public CustomerLogicBL()//IEditorService editorService,ICustomerLogic _logic)
        {
            //this.editorService = editorService;
            logic = new CustomerLogic();// _logic;
            this.messengerService = new Messenger(); //messengerService;
        }

        //public CustomerLogicBL(IEditorService editorService, IMessenger messengerService)
        //{
        //    this.editorService = editorService;
        //    this.messengerService = messengerService;
        //}

        public bool AddCustomer(CustomerVM newCustomer,ref int id)
        {
            try
            {
                Customer customer = FromVmToDbCustomer(newCustomer);
                Customer result = this.logic.AddNew(customer.Name, customer.Phone, customer.TravelAgencyId);
                id = result.Id;
                return true;
            }
            catch
            {
                return false;
            }


        }

        public int GetCustomerCount()
        {
            return this.logic.GetCustomerCount();
        }
        public bool DelCustomer(int customerId)
        {
            try
            {
                this.logic.DeleteCustomer(customerId);
                return true;
            }               
            catch
            {
                return false;
            }
            
        }

        public IList<CustomerVM> GetCustomers()
        {
            //this.logic = new CustomerLogic();
            return FromDbToVmCustomer(this.logic.GetAll().ToList());
        }

        public bool ModCustomer(CustomerVM customerToModify)
        {
            try { 
            if (customerToModify == null)
            {

                return false;
            }

            //CustomerVM clone = new CustomerVM();
            //clone.CopyFrom(customerToModify);
            //if (this.editorService.EditCustomer(clone) == true)
            {
                //customerToModify.CopyFrom(clone);

                this.logic.UpdateCustomer(customerToModify.Id, customerToModify.Name, customerToModify.Phone);
                //this.messengerService.Send("EDIT OK", "LogicResult");
                return true;
            }
        }
            catch

            {
                //this.messengerService.Send("EDIT CANCEL", "LogicResult");
                return false;
            }
        }

        private static IList<CustomerVM> FromDbToVmCustomer(IList<Customer> dbList)
        {
            IList<CustomerVM> conv = new List<CustomerVM>();
            foreach (Customer customer in dbList)
            {
                CustomerVM cu = new CustomerVM();
                cu.Id = customer.Id;
                cu.Name = customer.Name;
                cu.Phone = customer.Phone;
                cu.travelAgencyId = customer.TravelAgencyId;
                conv.Add(cu);
            }

            return conv;
        }

        private static Customer FromVmToDbCustomer(CustomerVM customer)
        {
            Customer cu = new Customer();
            cu.Id = customer.Id;
            cu.Name = customer.Name;
            cu.Phone = customer.Phone;
            cu.TravelAgencyId = customer.TravelAgencyId;
     
            return cu;
        }
    }
}
