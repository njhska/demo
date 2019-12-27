using System;
using System.Threading;
using System.Threading.Tasks;

namespace _15Thread
{
    public class ParallelDemo
    {
        public static void Go()
        {
            var cts = new CancellationTokenSource();
            //MaxDegreeOfParallelism cpu数量
            var po = new ParallelOptions { CancellationToken = cts.Token,MaxDegreeOfParallelism=4,TaskScheduler= TaskScheduler.Default};
            string[] str = { "wang","yong","jie"};
            Parallel.For(0, 1000, po,i=>Dosth(i));
            Parallel.ForEach(str, po,item => Dosth(item));
            Console.ReadKey();
        }
        private static void Dosth(int i)
        {
            Console.WriteLine(i);
        }
        private static void Dosth(string s)
        {
            Console.WriteLine(s);
        }
    }
}
