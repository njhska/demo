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
            List<string> list = new List<string>();
            person p = null;
            //list = p?.Names;
            if(p!=null&&p.Name!=null)
            {
                Console.WriteLine("haha");
            }
            var arr = list.Where(x => p != null && x == p.Name);
            Console.ReadKey();
        }
    }
    class person
    {
        public List<string> Names { get; set; }
        public string Name { get; set; }
    }
}
