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
        private static bool _CanClockWork = true;
        static void Main(string[] args)
        {
            //ViewProcessInformation();
            //ProcessManipulations();
            //ProcessTextFiles();
            //StartConsoleHeaderClock();

            var clock_thread = new Thread(StartConsoleHeaderClock);
            clock_thread.IsBackground = true;
            clock_thread.Name = "Поток милисекунд";
            clock_thread.Priority = ThreadPriority.Normal;


            clock_thread.Start();
            Console.WriteLine("Идентификатор потока часов: {0}", clock_thread.ManagedThreadId);

            Console.ReadLine();
            _CanClockWork = false;
            if (clock_thread.Join(200))
                clock_thread.Interrupt();
            //clock_thread.Join();
            //clock_thread.Interrupt();
            //clock_thread.Abort(); аборт - это убийство процесса!



            Console.WriteLine("Главный поток завершен!");
            Console.ReadLine();
            Console.WriteLine("Главный поток выгружен!");
        }

        private static void StartConsoleHeaderClock()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine("Запущен поток: id:{0}, name:{1}, priority:{3}",
                thread.ManagedThreadId, thread.Name, thread.Priority);

            while (_CanClockWork)
            {
                Console.Title = DateTime.Now.ToString("HH:mm:ss.ffff");
                Thread.Sleep(100);
            }

            Console.WriteLine("Поток часов завершен.");
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
