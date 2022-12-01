using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct Gravity
    {
        public Mech3DotNet.Types.Anim.Events.GravityMode mode;
        public float value;

        public Gravity(Mech3DotNet.Types.Anim.Events.GravityMode mode, float value)
        {
            this.mode = mode;
            this.value = value;
        }
    }

    public static class GravityConverter
    {
        public static readonly TypeConverter<Gravity> Converter = new TypeConverter<Gravity>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.GravityMode> mode;
            public Field<float> value;
        }

        public static void Serialize(Gravity v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("mode");
            s.Serialize(Mech3DotNet.Types.Anim.Events.GravityModeConverter.Converter)(v.mode);
            s.SerializeFieldName("value");
            ((Action<float>)s.SerializeF32)(v.value);
        }

        public static Gravity Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                mode = new Field<Mech3DotNet.Types.Anim.Events.GravityMode>(),
                value = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "mode":
                        fields.mode.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.GravityModeConverter.Converter)();
                        break;
                    case "value":
                        fields.value.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Gravity", fieldName);
                }
            }
            return new Gravity(

                fields.mode.Unwrap("Gravity", "mode"),

                fields.value.Unwrap("Gravity", "value")

            );
        }
    }
}
