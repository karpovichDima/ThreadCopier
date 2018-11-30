using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Controller
{
    class ScreenController
    {
        //private readonly IScreenService _screenService;
        private IInt _int;
        public ScreenController()
        {
            //IContainerDI _container = NinjectInit.GetInstance();
            //_container.Register<IScreenService, ScreenServiceImpl>();
            //_screenService = ComponentFactory.Resolve<IScreenService>();
        }

        public void ShowMessage()
        {
            _screenService.Show(new Screen { Bright = 54 });
        }

        
    }
}
