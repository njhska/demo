using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace _09Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new person();
            p.GetType().GetCustomAttributes();
            Console.ReadKey();
        }
    }
    class person
    { }
}
