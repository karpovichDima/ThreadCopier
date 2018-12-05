﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Model
{
    public class TaskQueue : IDisposable 
    {
        public const string Value = "\n";
        private readonly object _locker = new object();
        private readonly Thread[] _workers;
        private readonly Queue<ThreadServiceImpl.Task> _taskQ = new Queue<ThreadServiceImpl.Task>();
        private readonly CancellationTokenSource _cancelTokenSource;
        private readonly CancellationToken _token;

        private FileInfo[] _files;
        private int _counter = 0;

        public TaskQueue(int workerCount, FileInfo[] files)
        {
            _files = files;
            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;
            Console.WriteLine(Value + "Set 1 for decline task or other symbol for continue:");

            _workers = new Thread[workerCount];
            Console.WriteLine(Value + " Create and start a separate thread for each worker");
            for (var i = 0; i < workerCount; i++)
                (_workers[i] = new Thread(Consume)).Start();
        }

        public void Dispose()
        {
            Console.WriteLine(Value + "Enqueue one null task per worker to make each exit.");
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
                _taskQ.Enqueue(task);
                Monitor.PulseAll(_locker);
            }
        }

        private void Consume()
        {
            while (true)
            {
                if (_token.IsCancellationRequested) return;
                ThreadServiceImpl.Task task;
                lock (_locker)
                {
                    while (_taskQ.Count == 0) Monitor.Wait(_locker);
                    task = _taskQ.Dequeue();
                }

                if (task == null)
                {
                    Console.WriteLine(Value + "This signals our exit");
                    return;
                }

                Console.WriteLine(Value + "Simulate time-consuming task");

                if (_files.Length >= _counter)
                {
                    task(_files[_counter]);
                    _counter++;
                }
                
                /*var s = Console.ReadLine();
                if (s == "1") _cancelTokenSource.Cancel();*/
            }
        }
    }
}