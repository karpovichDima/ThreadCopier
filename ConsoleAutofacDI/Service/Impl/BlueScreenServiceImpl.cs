using System;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    public class BlueScreenServiceImpl : IScreenService
    {
        public void Show(Screen screen) => Console.WriteLine("2.BLUE SCREEN show image | bright:  " + screen.Bright);

        public void On(Screen screen) => Console.WriteLine("2.BLUE SCREEN on | bright:  ", screen.Bright);

        public void Off(Screen screen) => Console.WriteLine("2.BLUE SCREEN off");
    }
}