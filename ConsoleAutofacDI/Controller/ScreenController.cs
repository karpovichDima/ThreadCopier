using Autofac;
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
            var builder = new ContainerBuilder();
            builder.RegisterType<ScreenServiceImpl>().As<IScreenService>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                this.screenService = scope.Resolve<IScreenService>();
            }
            
        }

        public void ShowMessage()
        {
            screenService.Show(new Screen { Bright = 54 });
        }

        
    }
}
