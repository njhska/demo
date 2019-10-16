using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Struct
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Enum.GetValues(typeof(Color));
            Color c = (Color)1;
            var s = c.ToString();
            s = Enum.GetName(typeof(Color), 0);
            var o = Enum.Parse(typeof(Color), "1");
            Console.ReadKey();
        }
    }
    public enum Color
    {
        Red,
        Green,
        Blue
    }
}
