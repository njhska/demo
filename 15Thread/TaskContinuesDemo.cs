using System;
using System.Threading;
using System.Threading.Tasks;

namespace _15Thread
{
    public class TaskContinuesDemo
    {
        public static void Go()
        {
            //一个task可以有多个ContinueWith
            var t = Task.Run(() => Dosth(1000));
            //continue任务只有在任务顺利执行完时才执行
            t.ContinueWith(task => Console.WriteLine("the result is {0}", task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            //continue任务只有在任务抛出异常时才执行
            t.ContinueWith(task => Console.WriteLine("task throw {0}", task.Exception.InnerException), TaskContinuationOptions.OnlyOnFaulted);
            //continue任务只有在任务取消时才执行
            t.ContinueWith(task => Console.WriteLine("task was canceled"), TaskContinuationOptions.OnlyOnCanceled);
        }
        private static int Dosth(int num)
        {
            int result = 0;
            for (int i = 0; i < num; i++)
            {
                result += i;
            }
            return result;
        }
    }
}
