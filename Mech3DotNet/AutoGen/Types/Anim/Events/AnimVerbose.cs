using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class AnimVerbose
    {
        public static readonly TypeConverter<AnimVerbose> Converter = new TypeConverter<AnimVerbose>(Deserialize, Serialize);
        public bool on;

        public AnimVerbose(bool on)
        {
            this.on = on;
        }

        private struct Fields
        {
            public Field<bool> on;
        }

        public static void Serialize(AnimVerbose v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("on");
            ((Action<bool>)s.SerializeBool)(v.on);
        }

        public static AnimVerbose Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                on = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "on":
                        fields.on.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("AnimVerbose", fieldName);
                }
            }
            return new AnimVerbose(

                fields.on.Unwrap("AnimVerbose", "on")

            );
        }
    }
}
