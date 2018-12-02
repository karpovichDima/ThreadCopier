using System;
using Autofac;
using ConsoleAutofacDI.Controller;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;


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