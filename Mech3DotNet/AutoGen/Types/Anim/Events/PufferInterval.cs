using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class PufferInterval
    {
        public Mech3DotNet.Types.Anim.Events.PufferIntervalType intervalType;
        public float intervalValue;

        public PufferInterval(Mech3DotNet.Types.Anim.Events.PufferIntervalType intervalType, float intervalValue)
        {
            this.intervalType = intervalType;
            this.intervalValue = intervalValue;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<PufferInterval> Converter = new TypeConverter<PufferInterval>(Deserialize, Serialize);

        public static void Serialize(PufferInterval v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("interval_type");
            s.Serialize(Mech3DotNet.Types.Anim.Events.PufferIntervalTypeConverter.Converter)(v.intervalType);
            s.SerializeFieldName("interval_value");
            ((Action<float>)s.SerializeF32)(v.intervalValue);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.PufferIntervalType> intervalType;
            public Field<float> intervalValue;
        }

        public static PufferInterval Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                intervalType = new Field<Mech3DotNet.Types.Anim.Events.PufferIntervalType>(),
                intervalValue = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "interval_type":
                        fields.intervalType.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferIntervalTypeConverter.Converter)();
                        break;
                    case "interval_value":
                        fields.intervalValue.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("PufferInterval", fieldName);
                }
            }
            return new PufferInterval(

                fields.intervalType.Unwrap("PufferInterval", "intervalType"),

                fields.intervalValue.Unwrap("PufferInterval", "intervalValue")

            );
        }

        #endregion
    }
}
