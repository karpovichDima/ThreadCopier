using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Controller
{
    class ScreenController
    {
        internal IScreenService ScreenService { get; set; }

        public ScreenController()
        {
            ScreenService = AbstractContainer.AbsContainer.Resolve<IScreenService>();
        }

        public void ShowMessage()
        {
            ScreenService.Show(new Screen {Bright = 54});
        }


    }
}