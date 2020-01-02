using System;
using System.Threading;
using System.Threading.Tasks;

namespace _16AsyncMethod
{
    public static class Cancellation
    {
        private struct Void { }
        public static async Task WithCancellation(this Task task, CancellationToken ct)
        {
            //创建一个task名为tcs并设置它的状态
            var tcs = new TaskCompletionSource<Void>();
            //设置tcs为当ct取消时，tcs就完成
            using (ct.Register(t => ((TaskCompletionSource<Void>)t).TrySetResult(default(Void)), tcs))
            {
                //task和cts放在一起比较，如果cts先完成就抛出Operationcaceled错误
                if (await Task.WhenAny(task, tcs.Task) == tcs.Task) ct.ThrowIfCancellationRequested();
            }
            await task;
        }
    }
}
