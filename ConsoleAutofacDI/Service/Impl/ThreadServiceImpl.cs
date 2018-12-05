using System;
using System.Collections.Generic;
using System.IO;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    public class ThreadServiceImpl : IThreadService
    {
        public delegate void Task(FileInfo fileInfo);
        private Task _task;

        public static int ThreadCount = 144;
            
        public void StartCopyingFiles()
        {
            Queue<FileInfo> queueFiles = new Queue<FileInfo>();
            DirectoryInfo dr = new DirectoryInfo("W:\\Copy_1");
            foreach (FileInfo file in dr.GetFiles("*.txt"))
                queueFiles.Enqueue(file);
            TaskQueue taskQueue = new TaskQueue(ThreadCount, queueFiles);
            _task = Copier;
            for (int i = 0; i < queueFiles.Count; i++)
            {
                taskQueue.EnqueueTask(_task);
            }
        }
        
        private void Copier(FileInfo fileInfo)
        {
            string fileName = fileInfo.Name;
            fileInfo.CopyTo("W:\\Copy_2" + "\\" + fileName, true);
            Console.WriteLine("FILE " + fileName + " | IS COPIED");
        }  
    }
}

