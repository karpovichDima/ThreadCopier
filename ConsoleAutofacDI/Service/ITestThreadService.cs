using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAutofacDI.Service
{
    partial interface ITestThreadService
    {
        void CreateThreeTask();
        void TaskWithReturnValue();
        void TaskContinueWith();
        void ParallelsStart();
        void BreakTask();
        void BreakParallel();
        void WriteAsync();
        void CalculateFactorialAsync();
        void CreateTaskForWorkWithPattern();
    }
}
