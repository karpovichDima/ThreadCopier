using System;
using System.Threading.Tasks;

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
    }
}