using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace _14Serialize
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs = new List<string> { "wang", "yong", "jie" };
            var stream = SerializeToMemory(strs);
            stream.Position = 0;
            strs = null;

            strs = (List<string>)DeserializeFromMemory(stream);
            foreach (var item in strs)
            {
                Console.WriteLine(item);
            }

            var makeSerialize = new MakeSerialize(5, 5);
            stream = null;
            stream = SerializeToMemory(makeSerialize);
            stream.Position = 0;
            makeSerialize = null;
            makeSerialize = (MakeSerialize)DeserializeFromMemory(stream);

            Singleton[] sings = { Singleton.GetSingleton(),Singleton.GetSingleton() };
            using (var singStream =new MemoryStream())
            {
                BinaryFormatter singFormatter = new BinaryFormatter();
                singFormatter.Serialize(singStream, sings);
                singStream.Position = 0;
                sings = null;
                sings = (Singleton[])singFormatter.Deserialize(singStream);
            }

            Console.ReadKey();
        }
        private static MemoryStream SerializeToMemory(object obj)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();       
            formatter.Serialize(stream, obj);
            return stream;
        }
        private static object DeserializeFromMemory(Stream stream)
        {
            var formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
        private static object DeepClone(object original)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Context = new StreamingContext(StreamingContextStates.Clone);
                formatter.Serialize(stream, original);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }
    }
}
