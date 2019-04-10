using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    public class ThreadServiceImpl : IThreadService
    {
        public delegate void Task(FileInfo fileInfo);

        public static int ThreadCount = 1;
        
        public void StartCopyingFiles(CancellationTokenSource tokenSource)
        {
            var queueFiles = new Queue<FileInfo>();
            var directoryInfo = new DirectoryInfo("W:\\Copy_1");

            foreach (var file in directoryInfo.GetFiles("*.txt"))
            {
                queueFiles.Enqueue(file);
            }

            var queueTasks = new TaskQueue(ThreadCount, queueFiles, tokenSource);

            Task task = Copier;

            for (var i = 0; i < queueFiles.Count; i++)
            {
                queueTasks.EnqueueTask(task);
            }
        }

        private static void Copier(FileInfo fileInfo)
        {
            var fileName = fileInfo.Name;

            fileInfo.CopyTo("W:\\Copy_2" + "\\" + fileName, true);

            Console.WriteLine("FILE " + fileName + " | IS COPIED");
        }  
    }
}