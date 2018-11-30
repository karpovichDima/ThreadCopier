using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service
{
    interface IScreenService
    {
        void Show(Screen screen);
        void On(Screen screen);
        void Off(Screen screen);
    }
}
