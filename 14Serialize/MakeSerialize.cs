using System;
using System.Runtime.Serialization;
//标记类型可以被序列化
[Serializable]
public class MakeSerialize
{
    int x, y;
    //标记字段不能被序列化
    [NonSerialized]
    int sum;

    public MakeSerialize(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.sum = this.x + this.y;
    }
    [OnDeserializing]
    private void OnDeserializing(StreamingContext context)
    {
        //在格式化器反序列化类型前会调用此方法
        //所以如果反序列化后的结果才是真正结果
        this.x = 10;
        this.y = 10;
    }
    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        this.sum = this.x + this.y;
    }
}
