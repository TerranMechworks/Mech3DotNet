using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectDeleteChild
    {
        public string parent;
        public string child;

        public ObjectDeleteChild(string parent, string child)
        {
            this.parent = parent;
            this.child = child;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ObjectDeleteChild> Converter = new TypeConverter<ObjectDeleteChild>(Deserialize, Serialize);

        public static void Serialize(ObjectDeleteChild v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("parent");
            ((Action<string>)s.SerializeString)(v.parent);
            s.SerializeFieldName("child");
            ((Action<string>)s.SerializeString)(v.child);
        }

        private struct Fields
        {
            public Field<string> parent;
            public Field<string> child;
        }

        public static ObjectDeleteChild Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                parent = new Field<string>(),
                child = new Field<string>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
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
                        throw new UnknownFieldException("ObjectDeleteChild", fieldName);
                }
            }
            return new ObjectDeleteChild(

                fields.parent.Unwrap("ObjectDeleteChild", "parent"),

                fields.child.Unwrap("ObjectDeleteChild", "child")

            );
        }

        #endregion
    }
}
