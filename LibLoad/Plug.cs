using _11HotPlug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLoad
{
    [Serializable]
    public class Plug : IPlug
    {
        public void Dosth()
        {
            Console.WriteLine("no");
        }
    }
}
