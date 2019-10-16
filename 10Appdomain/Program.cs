using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.Runtime.Remoting;

class Program
{
    static void Main(string[] args)
    {
        Marshalling();
        Console.ReadKey();
    }
    private static void Marshalling()
    {
        //获取Appdomain 当前线程正在这个Appdomain中执行
        AppDomain callingThreadDomain = Thread.GetDomain();
        var callingDomainName = callingThreadDomain.FriendlyName;
        Console.WriteLine("default appdomain is {0}", callingDomainName);

        //获取并显示默认Appdomain中包含了main方法的程序集
        var exeAssembly = Assembly.GetEntryAssembly().FullName;
        Console.WriteLine("main assembly={0}", exeAssembly);

        AppDomain ad2 = null;
        MarshallByRefType mbrt = null;

        Console.WriteLine("{0}demo #1", Environment.NewLine);
        //创建一个Appdomain并从当前Appdomain继承安全性和配置
        ad2 = AppDomain.CreateDomain("ad #1", null, null);
        //将程序集加载到新的Appdomain中，构建一个对象，并把它封送回默认Appdomain
        //实际上得到的是对一个代理的引用
        mbrt = (MarshallByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "MarshallByRefType");
        Console.WriteLine("type={0}", mbrt.GetType());
        Console.WriteLine("is proxy={0}", RemotingServices.IsTransparentProxy(mbrt));
        //我们在代理上调用一个方法，代理使线程切换到真正拥有对象的Appdomain，并在真是的对象上调用方法
        mbrt.SomeMethod();
        //卸载Appdomain mbrt引用有效的代理，但是代理对象引用一个无效的Appdomain
        AppDomain.Unload(ad2);
        try
        {
            mbrt.SomeMethod();
            Console.WriteLine("successful call");
        }
        catch (AppDomainUnloadedException)
        {
            Console.WriteLine("failed call");
        }

        Console.WriteLine("{0}demo #2", Environment.NewLine);
        ad2 = AppDomain.CreateDomain("ad #2",null,null);
        mbrt = (MarshallByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "MarshallByRefType");
        //按值封送，返回了所返回对象的副本
        var mbvt = mbrt.MethodWithReturn();
        Console.WriteLine("type={0}", mbvt.GetType());
        Console.WriteLine("is proxy={0}", RemotingServices.IsTransparentProxy(mbvt));//得到的不是一个代理对象
        AppDomain.Unload(ad2);
        //卸载Appdomain，mbvt引用有效的对象
        try
        {
            Console.WriteLine(mbvt.ToString());
            Console.WriteLine("successful call");
        }
        catch (AppDomainUnloadedException)
        {
            Console.WriteLine("failed call");
        }

        Console.WriteLine("{0}demo #3", Environment.NewLine);
        ad2 = AppDomain.CreateDomain("ad #3", null, null);
        mbrt = (MarshallByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "MarshallByRefType");
        //不能封送的类型在两个Appdomain之间传递会报错
        var nmt = mbrt.MethodArgWithReturn(callingDomainName);
    }
}

public sealed class MarshallByRefType : MarshalByRefObject
{
    public MarshallByRefType()
    {
        Console.WriteLine("{0} ctor running in {1}", this.GetType().ToString(), Thread.GetDomain().FriendlyName);
    }
    public void SomeMethod()
    {
        Console.WriteLine("executing in {0}", Thread.GetDomain().FriendlyName);
    }
    public MarshallByValueType MethodWithReturn()
    {
        Console.WriteLine("executing in {0}", Thread.GetDomain().FriendlyName);
        return new MarshallByValueType();
    }
    public NonMarshalableType MethodArgWithReturn(string str)
    {
        Console.WriteLine("calling from {0} to {1}",str,Thread.GetDomain().FriendlyName);
        return new NonMarshalableType();
    }
}

[Serializable]
public sealed class MarshallByValueType
{
    private DateTime createTime = DateTime.Now;

    public MarshallByValueType()
    {
        Console.WriteLine("{0} ctor running in {1},created on {2:D}", this.GetType().ToString(), Thread.GetDomain().FriendlyName,createTime);
    }
    public override string ToString()
    {
        return $"tostring method running in {Thread.GetDomain().FriendlyName}";
    }
}

public sealed class NonMarshalableType
{
    public NonMarshalableType()
    {
        Console.WriteLine("{0} ctor running in {1}", this.GetType().ToString(), Thread.GetDomain().FriendlyName);
    }
}
