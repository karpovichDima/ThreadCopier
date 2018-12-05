using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Controller
{
    class ThreadController
    {
        internal IThreadService ThreadService { get; set; }

        public ThreadController()
        {
            ThreadService = AbstractContainer.AbsContainer.Resolve<IThreadService>();
        }

        public void StartCopyingFiles()
        {
            ThreadService.StartCopyingFiles();
        }
    }
}
