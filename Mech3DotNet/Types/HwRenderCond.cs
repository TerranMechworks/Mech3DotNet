using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct HwRenderCond
    {
        public bool value;

        public HwRenderCond(bool value)
        {
            this.value = value;
        }
    }

    public static class HwRenderCondConverter
    {
        public static readonly TypeConverter<HwRenderCond> Converter = new TypeConverter<HwRenderCond>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<bool> value;
        }

        public static void Serialize(HwRenderCond v, Serializer s)
        {
            s.SerializeStruct("HwRenderCond", 1);
            s.SerializeFieldName("value");
            ((Action<bool>)s.SerializeBool)(v.value);
        }

        public static HwRenderCond Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct("HwRenderCond"))
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("HwRenderCond", fieldName);
                }
            }
            return new HwRenderCond(

                fields.value.Unwrap("HwRenderCond", "value")

            );
        }
    }
}
