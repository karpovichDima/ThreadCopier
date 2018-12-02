using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.IoC.Impl;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Controller
{
    class ScreenController
    {
        public ScreenController()
        {
            var container = UnityInit.GetInstance();
            container.RegistrationDependency<IScreenService, BlackScreenServiceImpl>();
            ScreenService = container.Resolve<IScreenService>();
        }

        internal IScreenService ScreenService { get; set; }

        public void ShowMessage()
        {
            ScreenService.Show(new Screen { Bright = 54 });
        }

        
    }
}
