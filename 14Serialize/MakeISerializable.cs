using System;
using System.Runtime.Serialization;
using System.Reflection;
namespace _14Serialize
{
    public class BaseISerializable
    {
        protected string _name = "Jeff";
        protected string Name { get{ return _name; } }
        public BaseISerializable() { }
    }
    public class MakeISerializable : BaseISerializable, ISerializable
    {
        new private string _name = "Tom";
        public MakeISerializable() { }
        public MakeISerializable(SerializationInfo info, StreamingContext context)
        {
            Type baseType = this.GetType().BaseType;
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);
            for (int i = 0; i < mi.Length; i++)
            {
                FieldInfo fi = (FieldInfo)mi[i];
                fi.SetValue(this, info.GetValue($"{baseType.FullName}+{mi[i].Name}",fi.FieldType));
            }

            _name = info.GetString("Name");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", _name);
            Type baseType = this.GetType().BaseType;
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);
            for (int i = 0; i < mi.Length; i++)
            {
                info.AddValue($"{baseType.FullName}+{mi[i].Name}", ((FieldInfo)mi[i]).GetValue(this));
            }
        }
    }
}
