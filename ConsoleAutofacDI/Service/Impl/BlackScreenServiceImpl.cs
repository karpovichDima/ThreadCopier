using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    class BlackScreenServiceImpl : IScreenService
    {
        public void Show(Screen screen) => Console.WriteLine("1.BLACK SCREEN show image | bright:  " + screen.Bright);

        public void On(Screen screen) => Console.WriteLine("1.BLACK SCREEN on | bright:  ", screen.Bright);

        public void Off(Screen screen) => Console.WriteLine("1.BLACK SCREEN off");
    }
}
