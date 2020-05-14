using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ThreadingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ViewProcessInformation();

            var process = Process.Start("notepad");
            Console.ReadLine();

            Console.WriteLine("Процесс {0}", process.HasExited ? "выгружен" : "работает");
            Console.ReadLine();

            //process.Kill();

            var pid = process.Id;

            var pid_process = Process.GetProcessById(pid);
            pid_process.StandardInput

            pid_process.Kill();


            Console.WriteLine("Главный поток завершен!");
            Console.ReadLine();
        }


        private static void ViewProcessInformation()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                try
                {
                    Console.WriteLine("[pid:{0}] {1}", process.Id, process.ProcessName);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
