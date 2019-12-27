using System;
using System.Threading.Tasks;

namespace _15Thread
{
    public class TaskDemo
    {
        public static void Go()
        {
            Task<int> t = new Task<int>(x=> { return Dosth((int)x); },10000000);
            t.Start();
            t.Wait();
            Console.WriteLine("the sum is:{0}",t.Result);
            Console.ReadKey();
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
