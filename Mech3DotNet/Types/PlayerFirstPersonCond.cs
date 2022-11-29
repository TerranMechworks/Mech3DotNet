using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct PlayerFirstPersonCond
    {
        public bool value;

        public PlayerFirstPersonCond(bool value)
        {
            this.value = value;
        }
    }

    public static class PlayerFirstPersonCondConverter
    {
        public static readonly TypeConverter<PlayerFirstPersonCond> Converter = new TypeConverter<PlayerFirstPersonCond>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<bool> value;
        }

        public static void Serialize(PlayerFirstPersonCond v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("value");
            ((Action<bool>)s.SerializeBool)(v.value);
        }

        public static PlayerFirstPersonCond Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("PlayerFirstPersonCond", fieldName);
                }
            }
            return new PlayerFirstPersonCond(

                fields.value.Unwrap("PlayerFirstPersonCond", "value")

            );
        }
    }
}
