using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterComponents()
        {
            ComponentFactory.Register<IScreenService, ScreenServiceImpl>();
        }
    }   
}
