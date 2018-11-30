using Autofac;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.IoC
{
    public class AutofacInit : IContainerDI
    {
        private static AutofacInit sSoleInstance;

        public static IContainer container;
        public static ILifetimeScope scope;

        private AutofacInit(){}

        public static AutofacInit getInstance()
        {
            if (sSoleInstance == null)
            {
                sSoleInstance = new AutofacInit();
                var builder = new ContainerBuilder();
                builder.RegisterType<ScreenServiceImpl>().As<IScreenService>();
                container = builder.Build();
                scope = container.BeginLifetimeScope();
            }

            

            return sSoleInstance;
        }
    }
}