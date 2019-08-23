using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
namespace _04UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fixture f = new Fixture();
            //var num = f.Create<int>();
            //var p = f.Create<Person>();

            //var fly = new Mock<Fly>();
            //fly.Setup(g => g.Add(5, 5)).Returns(10);
            var person = new Person { Name = new PersonName { FirstName = "wang",LastName="xiaojie"} };
            var Name = person.GetType().GetProperty("Name").GetValue(person,null);
            var fn = person.GetType().GetProperty("Name").PropertyType.GetProperty("FirstName").GetValue(Name, null) as string;
            Console.WriteLine(fn);
            Console.ReadKey();
        }
    }
    class Person
    {
        public int Age { get; set; }
        public PersonName Name { get; set; }
    }
    class PersonName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public interface Fly
    {
        int Add(int a, int b);
    }
    public struct SomeType
    {
        public static readonly string abd = "";
    }
}
