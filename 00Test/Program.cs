﻿using System;
using System.Threading;
using System.Threading.Tasks;
namespace _00Test
{
    class Program
    {
        static void Main(string[] args)
        {
            StrangeBehavior.Go();
            Console.ReadKey();
        }
        
    }
    internal static class StrangeBehavior
    {
        // Compile with "/platform:x86 /o" and run it NOT under the debugger (Ctrl+F5)
        private static Boolean s_stopWorker = false;

        public static void Go()
        {
            Console.WriteLine("Main: letting worker run for 5 seconds");
            Thread t = new Thread(Worker);
            t.Start();
            Thread.Sleep(5000);
            s_stopWorker = true;
            Console.WriteLine("Main: waiting for worker to stop");
            t.Join();
            //Environment.Exit(0);
        }

        private static void Worker(Object o)
        {
            Int32 x = 0;
            while (!s_stopWorker) x++;
            Console.WriteLine("Worker: stopped when x={0}", x);
        }
    }
}
