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
            Fixture f = new Fixture();
            var num = f.Create<int>();
            var p = f.Create<Person>();

            var fly = new Mock<Fly>();
            fly.Setup(g => g.Add(5, 5)).Returns(10);
            var person = new Person();
            switch (person.Name)
            {

            }
            Console.ReadKey();
        }
    }
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
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
