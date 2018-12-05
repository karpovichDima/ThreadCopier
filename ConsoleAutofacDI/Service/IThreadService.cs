using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleAutofacDI.Service
{
    interface IThreadService
    {
        void StartCopyingFiles(CancellationTokenSource tokenSource, CancellationToken cancelToken);
    }
}
