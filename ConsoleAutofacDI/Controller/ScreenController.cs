using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Controller
{
    class ScreenController
    {
        private IScreenService screenService;

        public ScreenController()
        {
            IContainerDI container = AutofacInit.GetInstance();
            screenService = container.Resolve<IScreenService, ScreenServiceImpl> ();
        }

        public void ShowMessage()
        {
            screenService.Show(new Screen { Bright = 54 });
        }

        
    }
}
