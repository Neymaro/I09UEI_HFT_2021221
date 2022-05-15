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
    public class TravelAgencyLogicBL : ITravelAgencyLogicBL
    {
        private IEditorService editorService;
        private IMessenger messengerService;
        private ITravelAgencyLogic logic;
        public TravelAgencyLogicBL()//IEditorService editorService,ICustomerLogic _logic)
        {
            //this.editorService = editorService;
            logic = new TravelAgencyLogic();// _logic;
            this.messengerService = new Messenger(); //messengerService;
        }

        //public CustomerLogicBL(IEditorService editorService, IMessenger messengerService)
        //{
        //    this.editorService = editorService;
        //    this.messengerService = messengerService;
        //}
        public int GetTravelAgencyCount()
        {
            return this.logic.GetTravelAgencyCount();
        }
        public bool AddTravelAgency(TravelAgencyVM travelAgency, ref int id)
        {
            try
            {
                TravelAgency customer = FromVmToDbTravelAgency(travelAgency);
                TravelAgency result = this.logic.Create(customer.Name, customer.Rating);
                id = result.Id;
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool DelTravelAgency(int travelAgencyId)
        {
            try
            {
                this.logic.DeleteAgency(travelAgencyId);
                return true;
            }               
            catch
            {
                return false;
            }
            
        }

        public IList<TravelAgencyVM> GetTravelAgencies()
        {
            //this.logic = new CustomerLogic();
            return FromDbToVmTravelAgency(this.logic.GetAll().ToList());
        }

        public bool ModTravelAgency(TravelAgencyVM travelAgencyToModify)
        {
            try { 
            if (travelAgencyToModify == null)
            {

                return false;
            }

            //CustomerVM clone = new CustomerVM();
            //clone.CopyFrom(customerToModify);
            //if (this.editorService.EditCustomer(clone) == true)
            {
                //customerToModify.CopyFrom(clone);

                this.logic.Update(travelAgencyToModify.Id, travelAgencyToModify.Name, travelAgencyToModify.Rating);
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

        private static IList<TravelAgencyVM> FromDbToVmTravelAgency(IList<TravelAgency> dbList)
        {
            IList<TravelAgencyVM> conv = new List<TravelAgencyVM>();
            foreach (TravelAgency travelAgency in dbList)
            {
                TravelAgencyVM cu = new TravelAgencyVM();
                cu.Id = travelAgency.Id;
                cu.Name = travelAgency.Name;
                cu.Rating = travelAgency.Rating;
                conv.Add(cu);
            }

            return conv;
        }

        private static TravelAgency FromVmToDbTravelAgency(TravelAgencyVM customer)
        {
            TravelAgency cu = new TravelAgency();
            cu.Id = customer.Id;
            cu.Name = customer.Name;
            cu.Rating = customer.Rating;
     
            return cu;
        }
    }
}
