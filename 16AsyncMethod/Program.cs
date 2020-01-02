using System;

namespace _16AsyncMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //AsyncFuncCodeTransformation.Go();
            TaskLogger.Go().Wait();
            Console.ReadKey();
        }
    }
}
