using System;
using System.Runtime.Serialization;
[Serializable]
public sealed class Singleton : ISerializable
{
    private static readonly Singleton theOneObj = new Singleton();
    private Singleton() { }
    public string Name = "jeff";
    public DateTime Date = DateTime.Now;
    public static Singleton GetSingleton() { return theOneObj; }
    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        //调用这个方法格式化器将Singleton对象序列化为一个SingletonSerializationHelper对象
        //调用这个方法可以确保类型的全名和程序集被正确地设置
        info.SetType(typeof(SingletonSerializationHelper));
    }
    private sealed class SingletonSerializationHelper : IObjectReference
    {
        //反序列化时，由于流的对象是SingletonSerializationHelper
        //由于类型实现了IObjectReference接口
        //格式化器在反序列化时会调用GetRealObject方法
        public object GetRealObject(StreamingContext context)
        {
            return Singleton.GetSingleton();
        }
    }
}
