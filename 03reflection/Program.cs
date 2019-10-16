using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace _03reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var t = typeof(SomeType);
                //var model = Activator.CreateInstance(t);
                //var propertyInfo = t.GetTypeInfo().GetDeclaredProperty("Age");
                //propertyInfo.SetValue(model, 3);
                //Console.ReadKey();
                //var model = new SomeType(false, 12, "wyj");
                //model.qq.Add("4989");
                //model.qq.Add("21982");
                //var json = JsonConvert.SerializeObject(model);
                //Console.WriteLine(json);
                //var aa = JsonConvert.DeserializeObject<SomeType>(json);
                //var assembly = Assembly.Load(new AssemblyName("02ddd_demo"));
                //foreach (var item in t.GetProperties())
                //{
                //    Console.WriteLine(item.PropertyType);
                //}
                String a = "abc";
                String b = "abc";
                var result = object.ReferenceEquals(a, b);
                Console.ReadKey();
                System.Text.Encoding
            }
            catch (Exception e)
            {

                throw e;
            }


        }
    }
    class SomeType
    {
        public SomeType()
        { }
        public SomeType(bool sex, int age, string name)
        {
            this.Sex = sex;
            this.Age = age;
            this.Name = name;
            this.qq = new List<string>();
        }
        public bool Sex { get; private set; }
        public int Age { get; private set; }
        public string Name { get; private set; }
        public IList<string> qq { get; private set; }
        public int Dosth()
        {
            return 123;
        }
        public IList<Person> Persons { get; set; }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
    }
    public class ForceJSONSerializePrivatesResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            List<JsonProperty> jsonProps = new List<JsonProperty>();
            foreach (var prop in props)
            {
                jsonProps.Add(base.CreateProperty(prop, memberSerialization));
            }
            foreach (var field in type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
            {
                jsonProps.Add(base.CreateProperty(field, memberSerialization));
            }
            jsonProps.ForEach(p => { p.Writable = true; p.Readable = true; });
            return jsonProps;
        }
    }
}
