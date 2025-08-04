using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class PufferIntervalGarbage
    {
        public static readonly TypeConverter<PufferIntervalGarbage> Converter = new TypeConverter<PufferIntervalGarbage>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.PufferIntervalType intervalType;
        public bool hasIntervalType;
        public float intervalValue;
        public bool hasIntervalValue;

        public PufferIntervalGarbage(Mech3DotNet.Types.Anim.Events.PufferIntervalType intervalType, bool hasIntervalType, float intervalValue, bool hasIntervalValue)
        {
            this.intervalType = intervalType;
            this.hasIntervalType = hasIntervalType;
            this.intervalValue = intervalValue;
            this.hasIntervalValue = hasIntervalValue;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.PufferIntervalType> intervalType;
            public Field<bool> hasIntervalType;
            public Field<float> intervalValue;
            public Field<bool> hasIntervalValue;
        }

        public static void Serialize(PufferIntervalGarbage v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("interval_type");
            s.Serialize(Mech3DotNet.Types.Anim.Events.PufferIntervalTypeConverter.Converter)(v.intervalType);
            s.SerializeFieldName("has_interval_type");
            ((Action<bool>)s.SerializeBool)(v.hasIntervalType);
            s.SerializeFieldName("interval_value");
            ((Action<float>)s.SerializeF32)(v.intervalValue);
            s.SerializeFieldName("has_interval_value");
            ((Action<bool>)s.SerializeBool)(v.hasIntervalValue);
        }

        public static PufferIntervalGarbage Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                intervalType = new Field<Mech3DotNet.Types.Anim.Events.PufferIntervalType>(),
                hasIntervalType = new Field<bool>(),
                intervalValue = new Field<float>(),
                hasIntervalValue = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "interval_type":
                        fields.intervalType.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferIntervalTypeConverter.Converter)();
                        break;
                    case "has_interval_type":
                        fields.hasIntervalType.Value = d.DeserializeBool();
                        break;
                    case "interval_value":
                        fields.intervalValue.Value = d.DeserializeF32();
                        break;
                    case "has_interval_value":
                        fields.hasIntervalValue.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("PufferIntervalGarbage", fieldName);
                }
            }
            return new PufferIntervalGarbage(

                fields.intervalType.Unwrap("PufferIntervalGarbage", "intervalType"),

                fields.hasIntervalType.Unwrap("PufferIntervalGarbage", "hasIntervalType"),

                fields.intervalValue.Unwrap("PufferIntervalGarbage", "intervalValue"),

                fields.hasIntervalValue.Unwrap("PufferIntervalGarbage", "hasIntervalValue")

            );
        }
    }
}
