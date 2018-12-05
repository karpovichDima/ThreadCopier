using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    public class ThreadServiceImpl : IThreadService
    {
        public static int ThreadCount = 1;
        private string _pathInput = "W:\\Copy_1";
        private string _pathOutput = "W:\\Copy_2";
        private TaskQueue _taskQueue;
        private FileInfo[] _files;

        public delegate void Task(FileInfo fileInfo);
        private Task _task;
        
        public void StartCopyingFiles()
        {
            var dr = new DirectoryInfo(_pathInput);
            _files = dr.GetFiles("*.txt");
            _taskQueue = new TaskQueue(ThreadCount, _files);
            _task = Copier;
            for (int i = 0; i < _files.Length; i++)
            {
                _taskQueue.EnqueueTask(_task);
            }
        }
        
        private void Copier(FileInfo fileInfo)
        {
            string fileName = fileInfo.Name;
            fileInfo.CopyTo(_pathOutput + "\\" + fileName, true);
            Console.WriteLine("FILE " + fileName + " | IS COPIED");
        }  
    }
}

