using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAutofacDI.IoC
{
    public abstract class AbstractContainer
    {
        public static AbstractContainer AbsContainer;

        public abstract void RegistrationDependency<T, TN>() where T : class where TN : class, T;

        public abstract T Resolve<T>() where T : class;
    }
}
