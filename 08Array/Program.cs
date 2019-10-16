

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengths = new[] { 5,4};
            var lowerBounds = new[] { 2005,1};
            var arr = (Decimal[,])Array.CreateInstance(typeof(decimal), lengths, lowerBounds);
        }
    }
}
