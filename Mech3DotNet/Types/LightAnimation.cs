using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class LightAnimation
    {
        public static readonly TypeConverter<LightAnimation> Converter = new TypeConverter<LightAnimation>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Types.Range range;
        public Mech3DotNet.Types.Types.Color color;
        public float runtime;

        public LightAnimation(string name, Mech3DotNet.Types.Types.Range range, Mech3DotNet.Types.Types.Color color, float runtime)
        {
            this.name = name;
            this.range = range;
            this.color = color;
            this.runtime = runtime;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Types.Range> range;
            public Field<Mech3DotNet.Types.Types.Color> color;
            public Field<float> runtime;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.LightAnimation v, Serializer s)
        {
            s.SerializeStruct("LightAnimation", 4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Types.Range.Converter)(v.range);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Types.Color.Converter)(v.color);
            s.SerializeFieldName("runtime");
            ((Action<float>)s.SerializeF32)(v.runtime);
        }

        public static Mech3DotNet.Types.Anim.Events.LightAnimation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                range = new Field<Mech3DotNet.Types.Types.Range>(),
                color = new Field<Mech3DotNet.Types.Types.Color>(),
                runtime = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("LightAnimation"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Types.Range.Converter)();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Types.Color.Converter)();
                        break;
                    case "runtime":
                        fields.runtime.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("LightAnimation", fieldName);
                }
            }
            return new LightAnimation(

                fields.name.Unwrap("LightAnimation", "name"),

                fields.range.Unwrap("LightAnimation", "range"),

                fields.color.Unwrap("LightAnimation", "color"),

                fields.runtime.Unwrap("LightAnimation", "runtime")

            );
        }
    }
}
