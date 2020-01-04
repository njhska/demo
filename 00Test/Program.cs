using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace _00Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "y" };
            Dosth(ref p);
            Console.WriteLine(p.Name);
            Console.ReadKey();
        }
        static void Dosth(ref Person p)
        {
            p = new Person { Name = "x" };
        }
    }
    class Person
    {
        public string Name { get; set; }
        private List<string> list = new List<string>(); 
        public string this[int x]
        {
            get
            {
                return list[x];
            }
            set
            {
                list[x] = value;
            }
        }
    }
}
