using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00String
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "hello";
            //Encoding encodeingUTF8 = Encoding.;
            //Byte[] encodedBytes = encodeingUTF8.GetBytes(s);
            //string decodedString = encodeingUTF8.GetString(encodedBytes);

            //string s1 = "hello";
            //string s2 = "hello";
            //var t = object.ReferenceEquals(s1,s2);
            //Console.ReadKey();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}","hello","world").Replace(" ","-").AppendLine();
            sb.Insert(5,"all-").Remove(3,4);
        }
    }
}
