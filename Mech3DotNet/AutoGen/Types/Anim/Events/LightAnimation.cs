using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class LightAnimation
    {
        public string name;
        public Mech3DotNet.Types.Common.Range range;
        public Mech3DotNet.Types.Common.Color color;
        public float runTime;
        public Mech3DotNet.Types.Common.Range? rangeAlt = null;

        public LightAnimation(string name, Mech3DotNet.Types.Common.Range range, Mech3DotNet.Types.Common.Color color, float runTime, Mech3DotNet.Types.Common.Range? rangeAlt)
        {
            this.name = name;
            this.range = range;
            this.color = color;
            this.runTime = runTime;
            this.rangeAlt = rangeAlt;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<LightAnimation> Converter = new TypeConverter<LightAnimation>(Deserialize, Serialize);

        public static void Serialize(LightAnimation v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.range);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("run_time");
            ((Action<float>)s.SerializeF32)(v.runTime);
            s.SerializeFieldName("range_alt");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.rangeAlt);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Common.Range> range;
            public Field<Mech3DotNet.Types.Common.Color> color;
            public Field<float> runTime;
            public Field<Mech3DotNet.Types.Common.Range?> rangeAlt;
        }

        public static LightAnimation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                range = new Field<Mech3DotNet.Types.Common.Range>(),
                color = new Field<Mech3DotNet.Types.Common.Color>(),
                runTime = new Field<float>(),
                rangeAlt = new Field<Mech3DotNet.Types.Common.Range?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeF32();
                        break;
                    case "range_alt":
                        fields.rangeAlt.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("LightAnimation", fieldName);
                }
            }
            return new LightAnimation(

                fields.name.Unwrap("LightAnimation", "name"),

                fields.range.Unwrap("LightAnimation", "range"),

                fields.color.Unwrap("LightAnimation", "color"),

                fields.runTime.Unwrap("LightAnimation", "runTime"),

                fields.rangeAlt.Unwrap("LightAnimation", "rangeAlt")

            );
        }

        #endregion
    }
}
