using System;
using System.Threading.Tasks;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    class ThreadServiceImpl : IThreadService
    {
        public void CreateThreeTask()
        {
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine("start CreateThreeTask");
            Task[] tasks = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task"))
            };
            foreach (var element in tasks)
                element.Start();
            Task.WaitAll(tasks);
        }

        public void TaskWithReturnValue()
        {
            new Task<Screen>(() =>
            {
                Console.WriteLine("Task started");
                var screen = new Screen {Size = 7, Resolution = "1920*1080"};
                Console.WriteLine($"Size screen: {screen.Size} ||| Resolution: {screen.Resolution}");
                return screen;
            }).Start();
        }
    }
}