using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15Thread
{
    public class TaskFactoryDemo
    {
        public static void Go()
        {
            var parent = new Task(()=> {
                //所有由factory创建的task都共享cancellationToken
                //所有由factory创建的task都视为上层任务的子任务
                //所有由factory创建的task的后续任务都以同步方式执行
                //所有由factory创建的task都使用默认调度
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<int>(
                    cts.Token,
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default
                    );

                var childTasks = new[] {
                    tf.StartNew(()=>Dosth(cts.Token,10000)),
                    tf.StartNew(()=>Dosth(cts.Token,20000)),
                    tf.StartNew(()=>Dosth(cts.Token,Int32.MaxValue)),
                };

                //任何一个子任务抛出异常，就取消其他子任务
                for (int i = 0; i < childTasks.Length; i++)
                {
                    childTasks[i].ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
                }
                //创建一个task
                //当参数1中的所有task完成时，执行参数2的方法
                //后面的参数是采取的策略
                tf.ContinueWhenAll(childTasks,
                    completedTasks => completedTasks.Where(t => !t.IsCanceled && !t.IsFaulted).Max(t => t.Result),
                    CancellationToken.None
                    ).ContinueWith(t => Console.WriteLine("the max is {0}",t.Result),TaskContinuationOptions.ExecuteSynchronously);
            });

            parent.ContinueWith(p =>
            {
                var sb = new StringBuilder("exceptions:" + Environment.NewLine);
                foreach (var item in p.Exception.Flatten().InnerExceptions)
                {
                    sb.AppendLine(item.GetType().ToString());
                }
                Console.WriteLine(sb.ToString());
            });
            parent.Start();
        }
        private static int Dosth(CancellationToken token,int num)
        {
            int result = 0;
            for (int i = 0; i < num; i++)
            {
                token.ThrowIfCancellationRequested();
                result += i;
            }
            return result;
        }
    }
}
