using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Controller
{
    class ThreadController
    {
        private IThreadService _threadService;

        public ThreadController()
        {
            _threadService = AbstractContainer.AbsContainer.Resolve<IThreadService>();
        }

        public void CreateThreeTask()
        {
            _threadService.CreateThreeTask();
        }
    }
}
