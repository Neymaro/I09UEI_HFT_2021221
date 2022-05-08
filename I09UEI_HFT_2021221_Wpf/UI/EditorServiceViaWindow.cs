using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.UI
{
    class EditorServiceViaWindow
    {
        public bool EditUser(CustomerVM u)
        {
            EditWindow win = new EditWindow(u);
            return win.ShowDialog() ?? false;
        }
    }
}
