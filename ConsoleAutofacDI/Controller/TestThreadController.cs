using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;

namespace ConsoleAutofacDI.Controller
{
    public class TestThreadController
    {
        private readonly ITestThreadService _testThreadService;

        public TestThreadController()
        {
            _testThreadService = AbstractContainer.AbsContainer.Resolve<ITestThreadService>();
        }

        public void CreateThreeTask()
        {
            _testThreadService.CreateThreeTask();
        }

        public void TaskWithReturnValue()
        {
            _testThreadService.TaskWithReturnValue();
        }

        public void TaskContinueWith()
        {
            _testThreadService.TaskContinueWith();
        }

        public void ParallelsStart()
        {
            _testThreadService.ParallelsStart();
        }

        public void BreakTask()
        {
            _testThreadService.BreakTask();
        }

        public void BreakParallel()
        {
            _testThreadService.BreakParallel();
        }

        public void WriteAsync()
        {
            _testThreadService.WriteAsync();
        }

        public void CalculateFactorialAsync()
        {
            _testThreadService.CalculateFactorialAsync();
        }

        public void CreateTaskQueue()
        {
            _testThreadService.CreateTaskForWorkWithPattern();
        }
    }
}