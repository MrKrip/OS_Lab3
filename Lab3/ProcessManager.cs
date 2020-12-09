using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Lab3
{
    class ProcessManager
    { 
        private List<Process> test = new List<Process>();

        private class Process
        {
            private Random rand = new Random();
            public static int Counter { get; private set; } = 0;
            public static int AllExecTime { get; private set; } = 0;
            public int ID { get; private set; }
            public int ExecTime { get; private set; }
            public static int AllWaitTime { get; private set; } = 0;
            public int WaitTime { get; private set; }

            public Process()
            {
                ID = ++Counter;
                ExecTime = rand.Next(10001);
            }
            public static int CompareByTime(Process proc1, Process proc2)
            {
                return proc1.ExecTime.CompareTo(proc2.ExecTime);
            }
            public void print()
            {
                Console.WriteLine($"ID : {ID}\tExecution Time : {ExecTime}");
            }
            public void Execute()
            {
                //Console.WriteLine("------------------------------");
                AllExecTime += ExecTime;
                WaitTime = AllExecTime - ExecTime;
                AllWaitTime += WaitTime;
                /*Console.WriteLine($"Process {ID} running\nWait time : {WaitTime}");
                for (int i = 0; i < 10; i++)
                {
                    //Thread.Sleep(ExecTime / 10);
                    Console.Write("#");
                }
                Console.WriteLine();
                Console.WriteLine($"Process {ID} ended in {ExecTime} milliseconds");
                Console.WriteLine("------------------------------\n");*/
            }
            public static void Reset()
            {
                Counter = 0;
                AllExecTime = 0;
                AllWaitTime = 0;
            }
        }

       
        public void AddProcesses(int n)
        {
            for(int i=0;i<n;i++)
            {
                test.Add(new Process());
            }
        }
        public void start()
        {
            Console.WriteLine("All processes:");
            /*foreach(var proc in test)
            {
               proc.print();
            }
            Console.WriteLine("***********************************************************************");
            test.Sort(Process.CompareByTime);
            Console.WriteLine("All processes(sorted):");
            foreach (var proc in test)
            {
                proc.print();
            }*/

            Console.WriteLine("***********************************************************************");
            foreach (var proc in test)
            {
               proc.Execute();               
            }
            Console.WriteLine($"Avarage waiting time : {((Process.AllWaitTime)/Process.Counter)}");
            Console.WriteLine($"Avarage execution time : {Process.AllExecTime/Process.Counter}\n");           
            Console.WriteLine($"Total execution time : {Process.AllExecTime}");
            Console.WriteLine($"Total wait time : {Process.AllWaitTime}\n");
            test.Clear();
            Process.Reset();
            Console.WriteLine("***********************************************************************");
        }
    }
}
