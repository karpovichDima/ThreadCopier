using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace ConsoleAutofacDI.IoC.ComponentFactoryImpl
{
    class FactoryImplAutofac : ComponentFactory
    {
        private static ILifetimeScope _scope;

        public T Resolve<T>() where T : class
        {
            return _scope.Resolve<T>();
        }

        public static void Register<T, T1>()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<ScreenServiceImpl>().As<IScreenService>();
            _scope = builder.Build().BeginLifetimeScope();
            builder.RegisterType<T>().As<T1>();
        }
    }
}
