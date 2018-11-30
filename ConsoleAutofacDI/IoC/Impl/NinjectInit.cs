using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;
using Ninject;
using Ninject.Modules;

namespace ConsoleAutofacDI.IoC
{
    class NinjectInit : NinjectModule, IContainerDI
    {
        private static NinjectInit ninjectInit;
        public static IKernel kernel;


        private NinjectInit()
        {
        }

        public static NinjectInit getInstance()
        {
            if (ninjectInit == null)
            {
                ninjectInit = new NinjectInit();
                kernel = new StandardKernel(new NinjectInit());
            }
            return ninjectInit;
        }

        public override void Load()
        {
            Bind<IScreenService>().To<ScreenServiceImpl>();
        }
    }
}