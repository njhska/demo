using System;
using System.Threading;

namespace _15Thread
{
    public class TimerDemo
    {
        private static Timer timer;
        public static void Go()
        {
            //创建但不启动timer,使用Timeout.Infinite
            timer = new Timer(Dosth, null, Timeout.Infinite, Timeout.Infinite);
            //change方法会修改timer的时间项，并让timer重新规划运行计划
            //启动timer
            timer.Change(0, Timeout.Infinite);

            Console.ReadKey();
        }

        private static void Dosth(object o)
        {
            Console.WriteLine(DateTime.Now);
            Thread.Sleep(1000);
            //这样写，就不会出现任务没执行完，timer又启动一个线程去做任务
            timer.Change(2000, Timeout.Infinite);
        }
    }
}
