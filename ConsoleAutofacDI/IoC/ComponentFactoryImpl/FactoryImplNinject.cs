using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAutofacDI.IoC.ComponentFactoryImpl
{
    class FactoryImplNinject : ComponentFactory
    {
        public T Resolve<T>() where T : class
        {
            return _kernel.Get<T>();
        }

        /*
         * Сделать имплементацию, такую же, как для автофака, подумать над вызовом
         *
         */

    }
}
