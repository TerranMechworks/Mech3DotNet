using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class NodeRef
    {
        public static readonly TypeConverter<NodeRef> Converter = new TypeConverter<NodeRef>(Deserialize, Serialize);
        public string name;
        public uint ptr;

        public NodeRef(string name, uint ptr)
        {
            this.name = name;
            this.ptr = ptr;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<uint> ptr;
        }

        public static void Serialize(NodeRef v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
        }

        public static NodeRef Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                ptr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("NodeRef", fieldName);
                }
            }
            return new NodeRef(

                fields.name.Unwrap("NodeRef", "name"),

                fields.ptr.Unwrap("NodeRef", "ptr")

            );
        }
    }
}
