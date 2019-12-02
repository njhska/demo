using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;
namespace _15Thread
{
    public sealed class ThreadContext
    {
        public static void Go()
        {
            CallContext.LogicalSetData("name", "jeff");
            //context流向下个thread的context
            ThreadPool.QueueUserWorkItem(state => { Console.WriteLine($"name={CallContext.LogicalGetData("name")}"); });
            //阻止流动
            ExecutionContext.SuppressFlow();
            //这个thread的context不能访问上下文
            ThreadPool.QueueUserWorkItem(state => { Console.WriteLine($"name={CallContext.LogicalGetData("name")}"); });
            //恢复流动
            ExecutionContext.RestoreFlow();

            Console.ReadKey();
        }
    }
}
