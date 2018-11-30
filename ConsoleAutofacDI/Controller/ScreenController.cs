using Autofac;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service.Impl;
using Ninject;

namespace ConsoleAutofacDI.Controller
{
    class ScreenController
    {
        private IScreenService screenService;

        public ScreenController()
        {
            //  IContainerDI container = AutofacInit.getInstance();
            // screenService = AutofacInit.scope.Resolve<IScreenService>();
            IContainerDI container = NinjectInit.getInstance();
            screenService = NinjectInit.kernel.Get<ScreenServiceImpl>();
        }

        public void ShowMessage()
        {
            screenService.Show(new Screen { Bright = 54 });
        }

        
    }
}
