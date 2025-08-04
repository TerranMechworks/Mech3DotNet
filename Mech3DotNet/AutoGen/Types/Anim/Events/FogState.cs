using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FogState
    {
        public static readonly TypeConverter<FogState> Converter = new TypeConverter<FogState>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.FogType? type;
        public Mech3DotNet.Types.Common.Color? color;
        public Mech3DotNet.Types.Common.Range? altitude;
        public Mech3DotNet.Types.Common.Range? range;

        public FogState(Mech3DotNet.Types.Anim.Events.FogType? type, Mech3DotNet.Types.Common.Color? color, Mech3DotNet.Types.Common.Range? altitude, Mech3DotNet.Types.Common.Range? range)
        {
            this.type = type;
            this.color = color;
            this.altitude = altitude;
            this.range = range;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.FogType?> type;
            public Field<Mech3DotNet.Types.Common.Color?> color;
            public Field<Mech3DotNet.Types.Common.Range?> altitude;
            public Field<Mech3DotNet.Types.Common.Range?> range;
        }

        public static void Serialize(FogState v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("type_");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FogTypeConverter.Converter))(v.type);
            s.SerializeFieldName("color");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter))(v.color);
            s.SerializeFieldName("altitude");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.altitude);
            s.SerializeFieldName("range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.range);
        }

        public static FogState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                type = new Field<Mech3DotNet.Types.Anim.Events.FogType?>(),
                color = new Field<Mech3DotNet.Types.Common.Color?>(),
                altitude = new Field<Mech3DotNet.Types.Common.Range?>(),
                range = new Field<Mech3DotNet.Types.Common.Range?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "type_":
                        fields.type.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FogTypeConverter.Converter))();
                        break;
                    case "color":
                        fields.color.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter))();
                        break;
                    case "altitude":
                        fields.altitude.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    case "range":
                        fields.range.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("FogState", fieldName);
                }
            }
            return new FogState(

                fields.type.Unwrap("FogState", "type"),

                fields.color.Unwrap("FogState", "color"),

                fields.altitude.Unwrap("FogState", "altitude"),

                fields.range.Unwrap("FogState", "range")

            );
        }
    }
}
