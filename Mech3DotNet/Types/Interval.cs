using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Interval
    {
        public static readonly TypeConverter<Interval> Converter = new TypeConverter<Interval>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.IntervalType intervalType;
        public float intervalValue;
        public bool flag;

        public Interval(Mech3DotNet.Types.Anim.Events.IntervalType intervalType, float intervalValue, bool flag)
        {
            this.intervalType = intervalType;
            this.intervalValue = intervalValue;
            this.flag = flag;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.IntervalType> intervalType;
            public Field<float> intervalValue;
            public Field<bool> flag;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.Interval v, Serializer s)
        {
            s.SerializeStruct("Interval", 3);
            s.SerializeFieldName("interval_type");
            s.Serialize(Mech3DotNet.Types.Anim.Events.IntervalType.Converter)(v.intervalType);
            s.SerializeFieldName("interval_value");
            ((Action<float>)s.SerializeF32)(v.intervalValue);
            s.SerializeFieldName("flag");
            ((Action<bool>)s.SerializeBool)(v.flag);
        }

        public static Mech3DotNet.Types.Anim.Events.Interval Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                intervalType = new Field<Mech3DotNet.Types.Anim.Events.IntervalType>(),
                intervalValue = new Field<float>(),
                flag = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Interval"))
            {
                switch (fieldName)
                {
                    case "interval_type":
                        fields.intervalType.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.IntervalType.Converter)();
                        break;
                    case "interval_value":
                        fields.intervalValue.Value = d.DeserializeF32();
                        break;
                    case "flag":
                        fields.flag.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("Interval", fieldName);
                }
            }
            return new Interval(

                fields.intervalType.Unwrap("Interval", "intervalType"),

                fields.intervalValue.Unwrap("Interval", "intervalValue"),

                fields.flag.Unwrap("Interval", "flag")

            );
        }
    }
}
