using System;
using System.Threading;
using System.Threading.Tasks;

namespace _17ThreadSync
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int m = 0;
            Parallel.For(0,100000,(i)=> {
                n++;
            });
            Parallel.For(0, 100000, (i) => {
                Interlocked.Add(ref m,1);
            });
            Console.WriteLine(n);
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
}
