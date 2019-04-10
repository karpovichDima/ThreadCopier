namespace ConsoleAutofacDI.Service
{
    public interface ITestThreadService
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