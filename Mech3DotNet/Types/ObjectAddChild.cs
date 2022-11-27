using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectAddChild
    {
        public static readonly TypeConverter<ObjectAddChild> Converter = new TypeConverter<ObjectAddChild>(Deserialize, Serialize);
        public string parent;
        public string child;

        public ObjectAddChild(string parent, string child)
        {
            this.parent = parent;
            this.child = child;
        }

        private struct Fields
        {
            public Field<string> parent;
            public Field<string> child;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.ObjectAddChild v, Serializer s)
        {
            s.SerializeStruct("ObjectAddChild", 2);
            s.SerializeFieldName("parent");
            ((Action<string>)s.SerializeString)(v.parent);
            s.SerializeFieldName("child");
            ((Action<string>)s.SerializeString)(v.child);
        }

        public static Mech3DotNet.Types.Anim.Events.ObjectAddChild Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                parent = new Field<string>(),
                child = new Field<string>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ObjectAddChild"))
            {
                switch (fieldName)
                {
                    case "parent":
                        fields.parent.Value = d.DeserializeString();
                        break;
                    case "child":
                        fields.child.Value = d.DeserializeString();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectAddChild", fieldName);
                }
            }
            return new ObjectAddChild(

                fields.parent.Unwrap("ObjectAddChild", "parent"),

                fields.child.Unwrap("ObjectAddChild", "child")

            );
        }
    }
}
