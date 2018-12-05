using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    internal class TestTestThreadServiceImpl : ITestThreadService
    {
        private delegate void Tasks();

        private Tasks _task;
        
        public void CreateThreeTask()
        {
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine("start CreateThreeTask");
            Task[] tasks = {
                new Task(() => Console.WriteLine("First CustomTask")),
                new Task(() => Console.WriteLine("Second CustomTask")),
                new Task(() => Console.WriteLine("Third CustomTask"))
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
                Console.WriteLine("CustomTask started");
                var screen = new Screen {Size = 7, Resolution = "1920*1080"};
                Console.WriteLine($"Size screen: {screen.Size} ||| Resolution: {screen.Resolution}");
                return screen;
            }).Start();
        }

        public void TaskContinueWith()
        {
            Task task1 = new Task(() => { Console.WriteLine("CustomTask 1 started"); });
            Task task2 = task1.ContinueWith(Load);
            task1.Start();
            Console.WriteLine("CustomTask 2 start work");
            task2.Wait();
            Console.WriteLine("CustomTask 1 ended work");
            Console.WriteLine("CustomTask 2 ended work");
            Console.WriteLine("Main ended work");
        }

        private static void Load(Task t)
        {
            Console.WriteLine("task ID: " + t.Id);
            Thread.Sleep(3000);
        }

        public void ParallelsStart()
        {
            /* Parallel.Invoke(Display,
                 () =>
                 {
                     Console.WriteLine("Current task: " + CustomTask.CurrentId);
                     Thread.Sleep(3000);
                 },
                 () => Factorial(5));
             Console.ReadLine();*/
        }

        public void BreakTask()
        {
            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            var task1 = new Task(() =>
            {
                var result = 1;
                for (var i = 1; i <= 6; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("CustomTask breaking");
                        return;
                    }

                    result *= i;
                    Console.WriteLine("Factorial {0} equal {1}", i, result);
                    Thread.Sleep(5000);
                }
            });
            task1.Start();

            Console.WriteLine("Set Y for decline task or other symbol for continue:");
            var s = Console.ReadLine();
            if (s == "1")
                cancelTokenSource.Cancel();
        }

        public void BreakParallel()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            new Task(() =>
            {
                Thread.Sleep(400);
                cancelTokenSource.Cancel();
            }).Start();

            try
            {
                /*Parallel.ForEach<int>(new List<int>() {1, 2, 3, 4, 5, 6, 7, 8},
                    new ParallelOptions {CancellationToken = token}, Factorial);*/
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Break operation");
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            Console.ReadLine();
        }

        public void Display()
        {
            Console.WriteLine("Current task: " + Task.CurrentId);
            Thread.Sleep(3000);
        }

        public void Factorial()
        {
            int x = 4;
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            Console.WriteLine("Current task: " + Task.CurrentId);
            Thread.Sleep(3000);
            Console.WriteLine("Result: " + result);
        }

        public static int Factorial2(int x)
        {
            Thread.Sleep(3000);

            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            Console.WriteLine("Current task: " + Task.CurrentId);
            
            Console.WriteLine("Result: " + result);
            return result;
        }

        public async void ReadWriteAsync()
        {
            string s = "Hello";
            using (StreamWriter writer = new StreamWriter("W://file.txt", false))
            {
                Console.WriteLine("Start write");
                await writer.WriteLineAsync(s);
                Console.WriteLine("End write");
            }

            using (StreamReader reader = new StreamReader("W://file.txt"))
            {
                Console.WriteLine("Start read");
                string result = await reader.ReadToEndAsync();
                Console.WriteLine("End read");
                Console.WriteLine(result);
            }
        }

        public void WriteAsync()
        {
            ReadWriteAsync();
            Console.WriteLine("DoWork");
            Console.Read();
        }

        public void CalculateFactorialAsync()
        {
            Console.WriteLine("UI: DoWork");
            FactorialAsyncReturnValue(9);
            Console.WriteLine("UI: DoWork");
            Console.WriteLine("EndMainMethod");
        }

        public void CreateTaskForWorkWithPattern()
        {
            _task = Factorial;
            Console.WriteLine('\n' + "Start of creating queue");

            using(var taskQueue = new TestTaskQueue<Tasks>(1))
            {
                taskQueue.EnqueueTask(_task);
                taskQueue.EnqueueTask(_task);
                taskQueue.EnqueueTask(_task);
                taskQueue.EnqueueTask(_task);
                taskQueue.EnqueueTask(_task);
            }
        }

        private static async void FactorialAsyncReturnValue(int n)
        {
            Console.WriteLine("Started task");
            int x = await Task.Run(() => Factorial2(n));
            Console.WriteLine($"Factorial equal {x}");
        }
    }
}