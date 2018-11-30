using System;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;
using Ninject;
using Ninject.Modules;

namespace ConsoleAutofacDI.IoC
{
    class NinjectInit : NinjectModule
    {
        private static NinjectInit _ninjectInit;
        public static IKernel _kernel;

        public static NinjectInit GetInstance()
        {
            if (_ninjectInit != null) return _ninjectInit;
            _ninjectInit = new NinjectInit();
            _kernel = new StandardKernel(new NinjectInit());
            return _ninjectInit;
        }

        public override void Load()
        {
            Bind<IScreenService>().To<ScreenServiceImpl>();
        }

        
    }
}