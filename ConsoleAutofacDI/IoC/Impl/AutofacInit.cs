using Autofac;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;
using Ninject;

namespace ConsoleAutofacDI.IoC
{
    class AutofacInit
    {
        private static AutofacInit _instance;

        public static AutofacInit GetInstance()
        {
            return _instance ?? (_instance = new AutofacInit());
        }
    }
}