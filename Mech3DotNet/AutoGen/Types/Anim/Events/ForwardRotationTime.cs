using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ForwardRotationTime
    {
        public static readonly TypeConverter<ForwardRotationTime> Converter = new TypeConverter<ForwardRotationTime>(Deserialize, Serialize);
        public float initial;
        public float delta;

        public ForwardRotationTime(float initial, float delta)
        {
            this.initial = initial;
            this.delta = delta;
        }

        private struct Fields
        {
            public Field<float> initial;
            public Field<float> delta;
        }

        public static void Serialize(ForwardRotationTime v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("initial");
            ((Action<float>)s.SerializeF32)(v.initial);
            s.SerializeFieldName("delta");
            ((Action<float>)s.SerializeF32)(v.delta);
        }

        public static ForwardRotationTime Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                initial = new Field<float>(),
                delta = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "initial":
                        fields.initial.Value = d.DeserializeF32();
                        break;
                    case "delta":
                        fields.delta.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("ForwardRotationTime", fieldName);
                }
            }
            return new ForwardRotationTime(

                fields.initial.Unwrap("ForwardRotationTime", "initial"),

                fields.delta.Unwrap("ForwardRotationTime", "delta")

            );
        }
    }
}
