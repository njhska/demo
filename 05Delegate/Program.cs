using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Delegate
{
    internal delegate void SomeDel();
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
}
