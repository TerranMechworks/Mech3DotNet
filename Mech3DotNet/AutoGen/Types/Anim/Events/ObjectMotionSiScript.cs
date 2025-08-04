using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionSiScript
    {
        public static readonly TypeConverter<ObjectMotionSiScript> Converter = new TypeConverter<ObjectMotionSiScript>(Deserialize, Serialize);
        public string name;
        public uint index;

        public ObjectMotionSiScript(string name, uint index)
        {
            this.name = name;
            this.index = index;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<uint> index;
        }

        public static void Serialize(ObjectMotionSiScript v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("index");
            ((Action<uint>)s.SerializeU32)(v.index);
        }

        public static ObjectMotionSiScript Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                index = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "index":
                        fields.index.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionSiScript", fieldName);
                }
            }
            return new ObjectMotionSiScript(

                fields.name.Unwrap("ObjectMotionSiScript", "name"),

                fields.index.Unwrap("ObjectMotionSiScript", "index")

            );
        }
    }
}
