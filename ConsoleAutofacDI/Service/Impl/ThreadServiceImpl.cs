using System;
using System.Threading;
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
            Console.WriteLine("Tasks completed");
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

        public void TaskContinueWith()
        {
            Task task1 = new Task(() => {
                Console.WriteLine("Task 1 started");
            });
            Task task2 = task1.ContinueWith(Load);
            task1.Start();
            Console.WriteLine("Task 2 start work");
            task2.Wait();
            Console.WriteLine("Task 1 ended work");
            Console.WriteLine("Task 2 ended work");
            Console.WriteLine("Main ended work");
        }

        void Load(Task t)
        {
            Console.WriteLine("task ID: " + t.Id);
            Thread.Sleep(3000);
        }

        public void ParallelsStart()
        {
            Parallel.Invoke(Display,
                () => {
                    Console.WriteLine("Current task: " + Task.CurrentId);
                    Thread.Sleep(3000);
                },
                () => Factorial(5));
            Console.ReadLine();
        }

        public void BreakTask()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            int number = 6;

            Task task1 = new Task(() =>
            {
                int result = 1;
                for (int i = 1; i <= number; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task breaking");
                        return;
                    }

                    result *= i;
                    Console.WriteLine("Factorial {0} equal {1}", i, result);
                    Thread.Sleep(5000);
                }
            });
            task1.Start();

            Console.WriteLine("Set Y for decline task or other symbol for continue:");
            string s = Console.ReadLine();
            if (s == "Y")
                cancelTokenSource.Cancel();
        }

        static void Display()
        {
            Console.WriteLine("Current task: " +  Task.CurrentId);
            Thread.Sleep(3000);
        }

        static void Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Current task: " + Task.CurrentId);
            Thread.Sleep(3000);
            Console.WriteLine("Result: " + result);
        }
    }
}