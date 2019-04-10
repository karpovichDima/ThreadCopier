using System.Threading;

namespace ConsoleAutofacDI.Service
{
    interface IThreadService
    {
        void StartCopyingFiles(CancellationTokenSource tokenSource);
    }
}