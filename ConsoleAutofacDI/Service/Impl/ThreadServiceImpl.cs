using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAutofacDI.Service.Impl
{
    class ThreadServiceImpl : IThreadService
    {
        private string _pathInput = "W:\\Copy_1";
        private string _pathOutput = "W:\\Copy_2";

        public void StartCopyingFiles()
        {
            var dr = new DirectoryInfo(_pathInput);
            FileInfo[] files = dr.GetFiles("*.txt");

            foreach (FileInfo fi in files)
            {
                fi.CopyTo(_pathOutput + "\\" + fi.Name, true);
                Console.WriteLine("File " + fi.Name + " | IS COPIED");
            }

        }
    }
}
