using System;
using ConsoleAutofacDI.Controller;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service;


namespace ConsoleAutofacDI
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.RegisterComponents();
            var screenController = new ScreenController();
            screenController.ShowMessage();
            Console.ReadKey();
        }
    }
}