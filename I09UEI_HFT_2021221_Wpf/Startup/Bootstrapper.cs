using Autofac;
using GalaSoft.MvvmLight.Messaging;
using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using I09UEI_HFT_2021221_Wpf.BL;
using I09UEI_HFT_2021221_Wpf.UI;
using I09UEI_HFT_2021221_Wpf.VM;

namespace I09UEI_HFT_2021221_Wpf.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Main>().AsSelf();
            builder.RegisterType<Main>().AsSelf();
            builder.RegisterType<Customer>().AsSelf();
            //builder.RegisterType<IMessenger>().AsSelf();

            //builder.RegisterType<EditorServiceViaWindow>().As<IEditorService>();
            builder.RegisterType<CustomerLogicBL>().As<ICustomerLogicBL>();
            builder.RegisterType<CustomerLogic>().As<ICustomerLogic>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            return builder.Build();
        }
    }
}
