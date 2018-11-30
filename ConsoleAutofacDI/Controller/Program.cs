using System;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service;


namespace ConsoleAutofacDI
{
    class Program
    {
        private ScreenService screenService;

        static void Main(string[] args)
        {
            screenService.Show(new Screen {Bright = 54});
        }
    }
}
