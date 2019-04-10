using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Model
{
    public class TaskQueue : IDisposable
    {
        private readonly object _locker = new object();

        private readonly Thread[] _workers;

        private readonly CancellationTokenSource _tokenSource;

        private readonly Queue<ThreadServiceImpl.Task> _queueTasks;
        private readonly Queue<FileInfo> _queueFiles;

        public TaskQueue(int workerCount, 
                        Queue<FileInfo> queueFiles, 
                        CancellationTokenSource tokenSource)
        {
            _tokenSource = tokenSource;
            _queueFiles = queueFiles;
            _queueTasks = new Queue<ThreadServiceImpl.Task>();

            Console.WriteLine("\n Set 1 for decline task or other symbol for continue:");

            _workers = new Thread[workerCount];

            Console.WriteLine("\n Create and start a separate thread for each worker");
            for (var i = 0; i < workerCount; i++)
            {
                (_workers[i] = new Thread(Consume)).Start();
            }
        }

        public void Dispose()
        {
            Console.WriteLine("\n Enqueue one null task per worker to make each exit.");
            foreach (var worker in _workers)
            {
                EnqueueTask(null);
                worker.Join();
            }
        }

        public void EnqueueTask(ThreadServiceImpl.Task task)
        {
            lock (_locker)
            {
                _queueTasks.Enqueue(task);
                Monitor.PulseAll(_locker);
            }
        }

        private void Consume()
        {
            while (true)
            {
                if (_tokenSource.Token.IsCancellationRequested)
                {
                    return;
                }

                ThreadServiceImpl.Task task;

                lock (_locker)
                {
                    while (_queueTasks.Count == 0)
                    {
                        Monitor.Wait(_locker);
                    }

                    task = _queueTasks.Dequeue();
                }

                if (task == null)
                {
                    Console.WriteLine("\n This signals our exit");
                    return;
                }

                Console.WriteLine("\n Simulate time-consuming task");
                task(_queueFiles.Dequeue());

                if (_tokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        _tokenSource.Token.ThrowIfCancellationRequested();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("EXCEPTION - THE END");
                        return;
                    }
                }
            }
        }
    }
}