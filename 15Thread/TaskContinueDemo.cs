using System;
using System.Threading;
using System.Threading.Tasks;

namespace _15Thread
{
    public static class TaskContinueDemo
    {
        public static void Go()
        {
            Task<int> t = Task.Run(() => Dosth(1000000000));
            
            Thread.Sleep(1000);
            Console.WriteLine("main thread {0}", Thread.CurrentThread.ManagedThreadId);
            t.ContinueWith(task =>
            {
                Console.WriteLine("sum is {0}", task.Result);
                Console.WriteLine("continue task thread {0}",Thread.CurrentThread.ManagedThreadId);
            });
            t.ContinueWith(task =>
            {
                Console.WriteLine("sum is {0}", task.Result);
                Console.WriteLine("1continue task thread {0}", Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("do main work...");
            Console.ReadKey();
        }
        private static int Dosth(int num)
        {
            int result = 0;
            Console.WriteLine("task thread {0}",Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < num; i++)
            {
                result += i;
            }
            return result;
        }
    }
}
