using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleAutofacDI.Model
{
    public class TaskQueue<T> : IDisposable where T : class
    {
        private readonly object _locker = new object();
        private readonly Thread[] _workers;
        private readonly Queue<T> _taskQ = new Queue<T>();
        private readonly CancellationTokenSource _cancelTokenSource;
        private readonly CancellationToken _token;

        public TaskQueue(int workerCount)
        {
            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;

            Console.WriteLine("Set 1 for decline task or other symbol for continue:");

            _workers = new Thread[workerCount];
            Console.WriteLine("\n Create and start a separate thread for each worker");
            for (var i = 0; i < workerCount; i++)
                (_workers[i] = new Thread(Consume)).Start();
        }

        public void Dispose()
        {
            Console.WriteLine("\n Enqueue one null task per worker to make each exit.");
            foreach (Thread worker in _workers)
            {
                EnqueueTask(null);
                worker.Join();
            }
        }

        public void EnqueueTask(T task)
        {
            lock (_locker)
            {
                _taskQ.Enqueue(task);
                Monitor.PulseAll(_locker);
            }
        }

        void Consume()
        {
            while (true)
            {
                if (_token.IsCancellationRequested)
                {
                    Console.WriteLine("\n Task breaking");
                    return;
                }

                T task;
                lock (_locker)
                {
                    while (_taskQ.Count == 0) Monitor.Wait(_locker);
                    task = _taskQ.Dequeue();
                }

                if (task == null)
                {
                    Console.WriteLine("\n This signals our exit");
                    return;
                }

                Console.WriteLine("\n Simulate time-consuming task");
                Thread.Sleep(3000);

                string s = Console.ReadLine();
                if (s == "1")
                    _cancelTokenSource.Cancel();
            }
        }
    }
}