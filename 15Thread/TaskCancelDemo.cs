using System;
using System.Threading;
using System.Threading.Tasks;

namespace _15Thread
{
    public class TaskCancelDemo
    {
        public static void Go()
        {
            var cts = new CancellationTokenSource();
            var t = Task.Run(() => Dosth(cts.Token, 1000000000), cts.Token);
            //Console.ReadKey();
            cts.Cancel();//这是异步请求，task可能已经完成

            try
            {
                //如果任务已经取消,Result会抛出一个AggregateException
                //调用Result会抛出任务收集的异常，以及Result会抛出一个AggregateException
                Console.WriteLine("the sum id:{0}",t.Result);
            }
            catch (AggregateException x)
            {
                //AggregateException的handle方法,会调用回调为AggregateException中的每个exception做处理，如果处理完返回true则表示异常已处理
                //如果异常有一个没有处理，则创建一个AggregateException对象，只包含为处理异常，并抛出
                x.Handle(e => e is OperationCanceledException);
                Console.WriteLine("task was canceld");
            }

            Console.ReadKey();
        }
        private static int Dosth(CancellationToken token,int num)
        {
            int result = 0;
            for (int i = 0; i < num; i++)
            {
                //任务取消，下面这行代码抛出OperationCancekedException
                token.ThrowIfCancellationRequested();
                result += i;
            }
            return result;
        }
    }
}
