using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct PlayerRangeCond
    {
        public float value;

        public PlayerRangeCond(float value)
        {
            this.value = value;
        }
    }

    public static class PlayerRangeCondConverter
    {
        public static readonly TypeConverter<PlayerRangeCond> Converter = new TypeConverter<PlayerRangeCond>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> value;
        }

        public static void Serialize(PlayerRangeCond v, Serializer s)
        {
            s.SerializeStruct("PlayerRangeCond", 1);
            s.SerializeFieldName("value");
            ((Action<float>)s.SerializeF32)(v.value);
        }

        public static PlayerRangeCond Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("PlayerRangeCond"))
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("PlayerRangeCond", fieldName);
                }
            }
            return new PlayerRangeCond(

                fields.value.Unwrap("PlayerRangeCond", "value")

            );
        }
    }
}
