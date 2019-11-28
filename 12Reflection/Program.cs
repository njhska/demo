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
            var ass = Assembly.Load("LibLoad");
            //var ass = Assembly.LoadFrom(@"F:\mygit\demo\LibLoad\bin\Debug\LibLoad.dll");
            var tarr = ass.GetExportedTypes();
            foreach (var item in tarr)
            {
                Console.WriteLine(item.FullName);
                var typeInfo = item.GetTypeInfo();
                //Console.WriteLine(item.IsPublic);
                Activator.CreateInstance(item);
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;


            var openType = typeof(Dictionary<,>);
            var closeType = openType.MakeGenericType(typeof(String), typeof(Int32));
            var obj = Activator.CreateInstance(closeType);

            var pt = typeof(Person);
            var mis = pt.GetMembers();
            
            Console.ReadKey();
        }
        class Person
        {
            public string name = "aaa";
        }
        //嵌入式dll的
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var dllName = new AssemblyName(args.Name).Name + ".dll";
            var assem = Assembly.GetExecutingAssembly();
            var resourceName = assem.GetManifestResourceNames().FirstOrDefault(rn => rn.EndsWith(dllName));
            if (resourceName == null) return null;
            using (var stream = assem.GetManifestResourceStream(resourceName))
            {
                var assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
