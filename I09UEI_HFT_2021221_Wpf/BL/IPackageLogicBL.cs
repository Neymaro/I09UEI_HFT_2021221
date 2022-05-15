using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.BL
{
    public interface IPackageLogicBL
    {
        bool AddPackage(PackageVM package, ref int id);

        
        bool ModPackage(PackageVM packageToModify);


        bool DelPackage(int packageId);

      
        public IList<PackageVM> GetPackages();

        int GetPackageCount();
    }
}
