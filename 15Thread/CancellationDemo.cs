using System;
using System.Threading;

namespace _15Thread
{
    public static class CancellationDemo
    {
        public static void Go()
        {
            var cts = new CancellationTokenSource(5000);
            //向token注册cancel后的调用方法
            //useSynchronizationContext参数传递false则由调用cancel方法的线程顺序调用注册的回调方法
            //调用的顺序与注册的顺序相反
            cts.Token.Register(o => { Console.WriteLine(o); }, "5.register2", false);
            cts.Token.Register(o => { Console.WriteLine(o); }, "4.register1", false);
            //向token注册的方法后返回一个CancellationTokenRegistration对象，可以调用这个对象的dispose方法删除已登记的回调
            //CancellationTokenRegistration ctr = cts.Token.Register(o => { Console.WriteLine(o); }, "register3", false);
            //ctr.Dispose();
            //cts.Token.Register(o => { int n = 1/(int)o; }, 0, false);
            ThreadPool.QueueUserWorkItem(o => Dosth(cts.Token, 100));
            Console.WriteLine("1.press enter to cancel the operation.");
            Console.ReadKey();
            try
            {
                cts.Cancel();
            }
            catch (Exception e)
            {

                throw;
            }
            Console.WriteLine("6.main thread");
            Console.ReadLine();
        }

        private static void Dosth(CancellationToken token,int count)
        {
            for (int i = 0; i < count; i++)
            {
                if(token.IsCancellationRequested)
                {
                    Console.WriteLine("2.count is cancelled");
                    break;
                }
                Console.WriteLine(i);
                Thread.Sleep(200);
            }
            Console.WriteLine("3.count is done");
        }
    }
}
