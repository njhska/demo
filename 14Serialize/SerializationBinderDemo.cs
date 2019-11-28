using System;
using System.Runtime.Serialization;
public static class SerializationBinderDemo
{
    [Serializable]
    private sealed class Ver1
    {
        public int x = 1, y = 2, z = 3;
    }
    [Serializable]
    private sealed class Ver2 : ISerializable
    {
        int a, b, c;
        private Ver2(SerializationInfo info, StreamingContext context)
        {
            a = info.GetInt32("x");
            b = info.GetInt32("y");
            c = info.GetInt32("z");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }

    private sealed class Ver1ToVer2SerializationBinder : SerializationBinder
    {
        //反序列化时，格式化器从流中获取的数据
        public override Type BindToType(string assemblyName, string typeName)
        {
            //对流中的assemblyName和typeName进行判断
            //如果符合要转变的要求，就返回要反序列化的类型
            if (assemblyName == "xxx" && typeName == "Ver1")
                return typeof(Ver2);
            return Type.GetType($"{typeName},{assemblyName}");
        }
    }
}
