using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct AnimationLodCond
    {
        public uint value;

        public AnimationLodCond(uint value)
        {
            this.value = value;
        }
    }

    public static class AnimationLodCondConverter
    {
        public static readonly TypeConverter<AnimationLodCond> Converter = new TypeConverter<AnimationLodCond>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<uint> value;
        }

        public static void Serialize(AnimationLodCond v, Serializer s)
        {
            s.SerializeStruct("AnimationLodCond", 1);
            s.SerializeFieldName("value");
            ((Action<uint>)s.SerializeU32)(v.value);
        }

        public static AnimationLodCond Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("AnimationLodCond"))
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("AnimationLodCond", fieldName);
                }
            }
            return new AnimationLodCond(

                fields.value.Unwrap("AnimationLodCond", "value")

            );
        }
    }
}
