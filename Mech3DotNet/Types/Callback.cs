using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Callback
    {
        public static readonly TypeConverter<Callback> Converter = new TypeConverter<Callback>(Deserialize, Serialize);
        public uint value;

        public Callback(uint value)
        {
            this.value = value;
        }

        private struct Fields
        {
            public Field<uint> value;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.Callback v, Serializer s)
        {
            s.SerializeStruct("Callback", 1);
            s.SerializeFieldName("value");
            ((Action<uint>)s.SerializeU32)(v.value);
        }

        public static Mech3DotNet.Types.Anim.Events.Callback Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Callback"))
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Callback", fieldName);
                }
            }
            return new Callback(

                fields.value.Unwrap("Callback", "value")

            );
        }
    }
}
