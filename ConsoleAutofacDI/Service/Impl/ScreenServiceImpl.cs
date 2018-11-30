using System;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    class ScreenServiceImpl : ScreenService
    {
        public void Show(Screen screen) => Console.WriteLine("show image | bright:  ", screen.Bright);

        public void On(Screen screen) => Console.WriteLine("on | bright:  ", screen.Bright);

        public void Off(Screen screen) => Console.WriteLine("off");
    }
}
