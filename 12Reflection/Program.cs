using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _12Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"F:\mygit\demo\12Reflection\bin\Debug\LibLoad.dll";
            //Assembly ass = Assembly.LoadFile(path);
            //var t = ass.GetType("LibLoad.Plug");
            //IPlug plug = (IPlug)Activator.CreateInstance(t);
            //plug.Dosth();
            person p = new person("");
            Console.ReadKey();
        }
    }
    class person
    {
        public person(string str)
        {
            if (str == string.Empty)
            {
                name = "aaa";
                return;
            }
                
        }
        public string name { get; set; }
    }
}
