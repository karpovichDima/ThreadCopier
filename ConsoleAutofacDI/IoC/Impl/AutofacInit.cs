using Autofac;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;
using Ninject;

namespace ConsoleAutofacDI.IoC
{
    class AutofacInit : IContainerDI, ILabelIoC
    {
        private static AutofacInit insatnce;
        public static IContainer container;
        public static ILifetimeScope scope;

        public static AutofacInit GetInstance()
        {
            if (insatnce == null)
            {
                insatnce = new AutofacInit();
                var builder = new ContainerBuilder();
                builder.RegisterType<ScreenServiceImpl>().As<IScreenService>();
                container = builder.Build();
                scope = container.BeginLifetimeScope();
            }
            return insatnce;
        }

        public IScreenService Resolve()
        {
            return scope.Resolve<IScreenService>();
        }

        public T Resolve<T, TN>() where T : class where TN : class, T
        {
            return scope.Resolve<T>();
        }
    }
}