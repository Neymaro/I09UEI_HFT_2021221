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
    public class PackageLogicBL : IPackageLogicBL
    {
        private IEditorService editorService;
        private IMessenger messengerService;
        private IPackageLogic logic;
        public PackageLogicBL()//IEditorService editorService,ICustomerLogic _logic)
        {
            //this.editorService = editorService;
            logic = new PackageLogic();// _logic;
            this.messengerService = new Messenger(); //messengerService;
        }

        //public CustomerLogicBL(IEditorService editorService, IMessenger messengerService)
        //{
        //    this.editorService = editorService;
        //    this.messengerService = messengerService;
        //}

        public bool AddPackage(PackageVM package,ref int id)
        {
            try
            {
                Package customer = FromVmToDbPackage(package);
                Package result = this.logic.AddNewPackage(customer.Name, customer.Category, customer.Price, customer.VisaNeeded, customer.Description, customer.TravelAgencyId);
                id = result.Id;
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool DelPackage(int packageId)
        {
            try
            {
                this.logic.DeletePackage(packageId);
                return true;
            }               
            catch
            {
                return false;
            }
            
        }
        public int GetPackageCount()
        {
            return this.logic.GetPackageCount();
        }
        public IList<PackageVM> GetPackages()
        {
            //this.logic = new CustomerLogic();
            return FromDbToVmPackage(this.logic.GetAllPackages().ToList());
        }

        public bool ModPackage(PackageVM packageToModify)
        {
            try { 
            if (packageToModify == null)
            {

                return false;
            }

            //CustomerVM clone = new CustomerVM();
            //clone.CopyFrom(customerToModify);
            //if (this.editorService.EditCustomer(clone) == true)
            {
                //customerToModify.CopyFrom(clone);

                this.logic.Update(packageToModify.Id, packageToModify.Name, packageToModify.Category, packageToModify.Price, packageToModify.VisaNeeded, packageToModify.Description);
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

        private static IList<PackageVM> FromDbToVmPackage(IList<Package> dbList)
        {
            IList<PackageVM> conv = new List<PackageVM>();
            foreach (Package package in dbList)
            {
                PackageVM cu = new PackageVM();
                cu.Id = package.Id;
                cu.Name = package.Name;
                cu.Category = package.Category;
                cu.Description = package.Description;
                cu.Price = package.Price;
                cu.TravelAgencyId = package.TravelAgencyId;
                cu.VisaNeeded = package.VisaNeeded;
                conv.Add(cu);
            }

            return conv;
        }

        private static Package FromVmToDbPackage(PackageVM package)
        {
            Package cu = new Package();
            cu.Id = package.Id;
            cu.Name = package.Name;
            cu.Category = package.Category;
            cu.Description = package.Description;
            cu.Price = package.Price;
            cu.TravelAgencyId = package.TravelAgencyId;
            cu.VisaNeeded = package.VisaNeeded;
            return cu;
        }
    }
}
