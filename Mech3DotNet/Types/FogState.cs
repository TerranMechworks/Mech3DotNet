using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FogState
    {
        public static readonly TypeConverter<FogState> Converter = new TypeConverter<FogState>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.Events.FogType fogType;
        public Mech3DotNet.Types.Types.Color color;
        public Mech3DotNet.Types.Types.Range altitude;
        public Mech3DotNet.Types.Types.Range range;

        public FogState(string name, Mech3DotNet.Types.Anim.Events.FogType fogType, Mech3DotNet.Types.Types.Color color, Mech3DotNet.Types.Types.Range altitude, Mech3DotNet.Types.Types.Range range)
        {
            this.name = name;
            this.fogType = fogType;
            this.color = color;
            this.altitude = altitude;
            this.range = range;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.Events.FogType> fogType;
            public Field<Mech3DotNet.Types.Types.Color> color;
            public Field<Mech3DotNet.Types.Types.Range> altitude;
            public Field<Mech3DotNet.Types.Types.Range> range;
        }

        public static void Serialize(FogState v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("fog_type");
            s.Serialize(Mech3DotNet.Types.Anim.Events.FogType.Converter)(v.fogType);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Types.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("altitude");
            s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter)(v.altitude);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter)(v.range);
        }

        public static FogState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                fogType = new Field<Mech3DotNet.Types.Anim.Events.FogType>(),
                color = new Field<Mech3DotNet.Types.Types.Color>(),
                altitude = new Field<Mech3DotNet.Types.Types.Range>(),
                range = new Field<Mech3DotNet.Types.Types.Range>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "fog_type":
                        fields.fogType.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.FogType.Converter)();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Types.ColorConverter.Converter)();
                        break;
                    case "altitude":
                        fields.altitude.Value = d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter)();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("FogState", fieldName);
                }
            }
            return new FogState(

                fields.name.Unwrap("FogState", "name"),

                fields.fogType.Unwrap("FogState", "fogType"),

                fields.color.Unwrap("FogState", "color"),

                fields.altitude.Unwrap("FogState", "altitude"),

                fields.range.Unwrap("FogState", "range")

            );
        }
    }
}
