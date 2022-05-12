using I09UEI_HFT_2021221_Wpf.BL;
using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.UI
{
    public class EditorServiceViaWindow : IEditorService
    {
        public bool EditCustomer(CustomerVM customer)
        {
            EditWindow win = new EditWindow(customer);
            return win.ShowDialog() ?? false;
        }

        //public bool EditUser(CustomerVM u)
        //{
        //    EditWindow win = new EditWindow(u);
        //    return win.ShowDialog() ?? false;
        //}
    }
}
