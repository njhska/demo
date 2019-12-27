using System;
using System.Threading;
using System.Threading.Tasks;

namespace _15Thread
{
    public class ChildTaskDemo
    {
        public static void Go()
        {
            var parent = new Task<int[]>(() =>
            {
                int[] result = new int[3];

                new Task(() => result[0] = Dosth(1000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = Dosth(1001), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = Dosth(1002), TaskCreationOptions.AttachedToParent).Start();

                return result;
            });

            parent.Start();

            parent.ContinueWith(parentTask => Array.ForEach(parentTask.Result, Console.Write));

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
