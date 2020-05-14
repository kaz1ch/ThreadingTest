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
            //ProcessManipulations();
            //ProcessTextFiles();
            StartConsoleHeaderClock();
            


            Console.WriteLine("Главный поток завершен!");
            Console.ReadLine();
        }

        private static void StartConsoleHeaderClock()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString("HH:mm:ss.ffff");
                Thread.Sleep(100);
            }
        }

        private static void ProcessTextFiles()
        {
            var started_process_info = new ProcessStartInfo("123.txt")
            {
                UseShellExecute = true
            };

            var started_process = Process.Start(started_process_info);
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

        private static void ProceesManipulation()
        {
            var process = Process.Start("notepad");
            Console.ReadLine();

            Console.WriteLine("Процесс {0}", process.HasExited ? "выгружен" : "работает");
            Console.ReadLine();

            //process.Kill();

            var pid = process.Id;

            var pid_process = Process.GetProcessById(pid);

            pid_process.PriorityClass = ProcessPriorityClass.High;
            Console.WriteLine(pid_process.PriorityClass);


            Console.ReadLine();
            Console.WriteLine("ВЫгружаю процесс");
            pid_process.Kill();
        }
    }
}
