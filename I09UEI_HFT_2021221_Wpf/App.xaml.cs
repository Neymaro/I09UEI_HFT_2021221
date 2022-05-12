using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using I09UEI_HFT_2021221_Wpf.BL;
using I09UEI_HFT_2021221_Wpf.UI;
using System.Windows;

namespace I09UEI_HFT_2021221_Wpf
{
    /// <summary
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {

        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);

            MyIoc.Instance.Register<ICustomerLogicBL, CustomerLogicBL>();

            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();

        }
    }



}
