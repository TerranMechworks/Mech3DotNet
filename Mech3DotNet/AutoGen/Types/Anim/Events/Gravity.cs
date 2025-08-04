using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Gravity
    {
        public static readonly TypeConverter<Gravity> Converter = new TypeConverter<Gravity>(Deserialize, Serialize);
        public float value;
        public bool complex;
        public bool noAltitude;

        public Gravity(float value, bool complex, bool noAltitude)
        {
            this.value = value;
            this.complex = complex;
            this.noAltitude = noAltitude;
        }

        private struct Fields
        {
            public Field<float> value;
            public Field<bool> complex;
            public Field<bool> noAltitude;
        }

        public static void Serialize(Gravity v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("value");
            ((Action<float>)s.SerializeF32)(v.value);
            s.SerializeFieldName("complex");
            ((Action<bool>)s.SerializeBool)(v.complex);
            s.SerializeFieldName("no_altitude");
            ((Action<bool>)s.SerializeBool)(v.noAltitude);
        }

        public static Gravity Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<float>(),
                complex = new Field<bool>(),
                noAltitude = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeF32();
                        break;
                    case "complex":
                        fields.complex.Value = d.DeserializeBool();
                        break;
                    case "no_altitude":
                        fields.noAltitude.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("Gravity", fieldName);
                }
            }
            return new Gravity(

                fields.value.Unwrap("Gravity", "value"),

                fields.complex.Unwrap("Gravity", "complex"),

                fields.noAltitude.Unwrap("Gravity", "noAltitude")

            );
        }
    }
}
