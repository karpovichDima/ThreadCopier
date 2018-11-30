using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAutofacDI.Service
{
    class Class1 : IINt
    {
        public Class1(IScreenService service)
        {
                
        }

        void m()
        {
            service.Show();
        }
    }
}
