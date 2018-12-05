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

        private CancellationTokenSource _tokenSource;
        private CancellationToken _cancelToken;

        public ThreadController()
        {
            _tokenSource = new CancellationTokenSource();
            _cancelToken = _tokenSource.Token;
            ThreadService = AbstractContainer.AbsContainer.Resolve<IThreadService>();
        }

        public void StartCopyingFiles()
        {
            Task.Run(() => ThreadService.StartCopyingFiles(_tokenSource, _cancelToken));
            var readLine = Console.ReadLine();
            if (readLine == "#")
            {
                _tokenSource.Cancel();
            }
        }
    }
}
