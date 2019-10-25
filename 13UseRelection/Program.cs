using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _13UseRelection
{
    class Program
    {
        static void Main(string[] args)
        {
            BindToMemberThenInvokeTheMember(typeof(SomeType));
            UseDynamicToBindAndInvokeTheMember(typeof(SomeType));
            Console.ReadKey();
        }
        private static void BindToMemberThenInvokeTheMember(Type t)
        {
            Console.WriteLine("BindToMemberThenInvokeTheMember");
            var ctorArgType = typeof(int).MakeByRefType();
            var ctor = t.GetTypeInfo().DeclaredConstructors.First(x=>x.GetParameters()[0].ParameterType == ctorArgType);
            var ctorArg = new object[] { 12 };
            Console.WriteLine("x before ctor call:{0}",ctorArg[0]);
            var obj = ctor.Invoke(ctorArg);
            Console.WriteLine("type:{0}",obj.GetType());
            Console.WriteLine("x after ctor call:{0}", ctorArg[0]);

            var fi = obj.GetType().GetTypeInfo().GetDeclaredField("someField");
            fi.SetValue(obj,34);
            Console.WriteLine("someFile:{0}", fi.GetValue(obj));

            var pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
            try
            {
                pi.SetValue(obj, 0);
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException.GetType() != typeof(ArgumentOutOfRangeException)) throw;
                Console.WriteLine("Property set error");
            }
            pi.SetValue(obj, 7);
            Console.WriteLine("someProp:{0}", pi.GetValue(obj));

            var ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
            var eh = new EventHandler(EventCallBack);
            ei.AddEventHandler(obj,eh);
            ei.RemoveEventHandler(obj,eh);
        }
        private static void UseDynamicToBindAndInvokeTheMember(Type t)
        {
            Console.WriteLine("UseDynamicToBindAndInvokeTheMember");
            var args = new object[] { 12};
            Console.WriteLine("x before ctor call:{0}", args[0]);
            dynamic obj = Activator.CreateInstance(t, args);
            Console.WriteLine("type:{0}", obj.GetType());
            Console.WriteLine("x after ctor call:{0}", args[0]);
            try
            {
                obj.someField = 5;
                var v = (int)obj.someField;
                Console.WriteLine("someFile:{0}", v);
            }
            catch (RuntimeBinderException e)
            {
                Console.WriteLine("failed to access field:{0}", e.Message);
            }
            try
            {
                obj.SomeProp = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Property set error");
            }
            obj.SomeProp = 12;
            var pv = (int)obj.SomeProp;
            Console.WriteLine("someProp:{0}", pv);

            var s = (string)obj.ToString();
            Console.WriteLine("ToString:{0}", s);

            obj.SomeEvent += new EventHandler(EventCallBack);
            obj.SomeEvent -= new EventHandler(EventCallBack);
        }
        private static void EventCallBack(object sender, EventArgs e) { }
    }

    internal sealed class SomeType
    {
        private int someField;
        public SomeType(ref int x)
        {
            x *= 2;
        }
        public int SomeProp
        {
            get { return someField; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value");
                someField = value;
            }
        }
        public override string ToString()
        {
            return someField.ToString();
        }
        public event EventHandler SomeEvent;
        private void Dosth()
        {
            SomeEvent.ToString();
        }
    }
}
