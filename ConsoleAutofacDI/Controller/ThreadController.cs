using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service;

namespace ConsoleAutofacDI.Controller
{
    class ThreadController
    {
        internal IThreadService ThreadService { get; set; }

        private readonly CancellationTokenSource _tokenSource;

        public ThreadController()
        {
            _tokenSource = new CancellationTokenSource();
            ThreadService = AbstractContainer.AbsContainer.Resolve<IThreadService>();
        }

        public void StartCopyingFiles()
        {
            Task.Run(() => ThreadService.StartCopyingFiles(_tokenSource, _tokenSource.Token));
            var readLine = Console.ReadLine();
            if (readLine == "#")
            {
                _tokenSource.Cancel();
            }
        }
    }
}
