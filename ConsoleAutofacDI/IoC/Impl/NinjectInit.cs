using System;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;
using Ninject;
using Ninject.Modules;

namespace ConsoleAutofacDI.IoC
{
    class NinjectInit : NinjectModule, IContainerDI, ILabelIoC
    {
        private static NinjectInit ninjectInit;
        public static IKernel kernel;

        public static NinjectInit GetInstance()
        {
            if (ninjectInit != null) return ninjectInit;
            ninjectInit = new NinjectInit();
            kernel = new StandardKernel(new NinjectInit());
            return ninjectInit;
        }

        public override void Load()
        {
            Bind<IScreenService>().To<ScreenServiceImpl>();
        }


        public T Resolve<T, TN>() where T : class where TN : class, T
        {
            return kernel.Get<T>();
        }
    }
}