using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    public class ThreadServiceImpl : IThreadService
    {
        public delegate void Task(FileInfo fileInfo);
        private Task _task;

        public static int ThreadCount = 1;
            
        public void StartCopyingFiles(CancellationTokenSource tokenSource, CancellationToken cancelToken)
        {
            var queueFiles = new Queue<FileInfo>();
            var dr = new DirectoryInfo("W:\\Copy_1");
            foreach (var file in dr.GetFiles("*.txt"))
                queueFiles.Enqueue(file);
            var taskQueue = new TaskQueue(ThreadCount, queueFiles, tokenSource, cancelToken);
            _task = Copier;
            for (var i = 0; i < queueFiles.Count; i++)
                taskQueue.EnqueueTask(_task);
        }
        
        private static void Copier(FileInfo fileInfo)
        {
            string fileName = fileInfo.Name;
            fileInfo.CopyTo("W:\\Copy_2" + "\\" + fileName, true);
            Console.WriteLine("FILE " + fileName + " | IS COPIED");
        }  
    }
}