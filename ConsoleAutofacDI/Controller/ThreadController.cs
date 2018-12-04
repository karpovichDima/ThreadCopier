using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;

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

        public void TaskWithReturnValue()
        {
            _threadService.TaskWithReturnValue();
        }

        public void TaskContinueWith()
        {
            _threadService.TaskContinueWith();
        }

        public void ParallelsStart()
        {
            _threadService.ParallelsStart();
        }

        public void BreakTask()
        {
            _threadService.BreakTask();
        }

        public void BreakParallel()
        {
            _threadService.BreakParallel();
        }

        public void WriteAsync()
        {
            _threadService.WriteAsync();
        }

        public void CalculateFactorialAsync()
        {
            _threadService.CalculateFactorialAsync();
        }
    }
}