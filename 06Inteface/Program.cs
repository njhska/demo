using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Inteface
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public interface ISomeItf
    {
        void Dosth();
    }
    public class SomeType : ISomeItf
    {
        public virtual void Dosth()
        {
            throw new NotImplementedException();
        }
    }
}
