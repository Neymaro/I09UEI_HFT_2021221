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
        public CustomerLogicBL(IEditorService editorService,ICustomerLogic _logic)
        {
            this.editorService = editorService;
            logic = _logic;
            //this.messengerService = messengerService;
        }

        //public CustomerLogicBL(IEditorService editorService, IMessenger messengerService)
        //{
        //    this.editorService = editorService;
        //    this.messengerService = messengerService;
        //}

        public void AddCustomer(IList<CustomerVM> list)
        {
            CustomerVM newCustomer = new CustomerVM();
            if (this.editorService.EditCustomer(newCustomer) == true)
            {
                if (list == null)
                {
                    throw new ArgumentNullException(nameof(list));
                }
                else
                {
                    list.Add(newCustomer);
                    this.messengerService.Send("ADD OK", "LogicResult");
                    Customer customer = FromVmToDbCustomer(newCustomer);
                    this.logic.AddNew(customer.Name, customer.Phone, customer.TravelAgencyId);
                }
            }
            else
            {
                this.messengerService.Send("ADD CNACELED", "LogicResult");
            }


        }

        public void DelCustomer(IList<CustomerVM> list, CustomerVM customer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            else
            {
                if (customer != null && list.Remove(customer))
                {
                    this.logic.DeleteCustomer(customer.Id);
                    this.messengerService.Send("DELETE OK", "LogicResult");
                }
                else
                {
                    this.messengerService.Send("DELETE FAIL", "LogicResult");
                }
            }
        }

        public IList<CustomerVM> GetCustomers()
        {
            //this.logic = new CustomerLogic();
            return FromDbToVmCustomer(this.logic.GetAll().ToList());
        }

        public void ModCustomer(CustomerVM customerToModify)
        {
            if (customerToModify == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            CustomerVM clone = new CustomerVM();
            clone.CopyFrom(customerToModify);
            if (this.editorService.EditCustomer(clone) == true)
            {
                customerToModify.CopyFrom(clone);
              
                this.logic.UpdateCustomer(customerToModify.Id, customerToModify.Name, customerToModify.Phone);
                this.messengerService.Send("EDIT OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("EDIT CANCEL", "LogicResult");
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
            cu.TravelAgencyId = customer.travelAgencyId;
     
            return cu;
        }
    }
}
