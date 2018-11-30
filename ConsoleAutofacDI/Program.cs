using System;
using ConsoleAutofacDI.Controller;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service;


namespace ConsoleAutofacDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var screenController = new ScreenController();
            screenController.ShowMessage();
            Console.ReadKey();
        }
    }
}