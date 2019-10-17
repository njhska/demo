using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Delegate
{
    internal delegate void SomeDel();
    internal delegate TResult SomeDel2<in T, out TResult>(T t);
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class SomeType
    {
        static void Dosth()
        {
            //SomeType2.Dosth(new SomeDel(SomeMethod));
        }
        private static void SomeMethod()
        {

        }
    }
    class SomeType2
    {
        protected void Dosth(SomeDel d)
        {
            d();
        }
    }
    class SomeType3:SomeType2
    {
        
    }
    interface ISomePort<in T,out P>
    {
        P Dosth(T t);
    }
    class SomeType4 : ISomePort<int, string>
    {
        public string Dosth(int t)
        {
            throw new NotImplementedException();
        }
        //public string 
    }
}
