using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class PufferStateTexture
    {
        public static readonly TypeConverter<PufferStateTexture> Converter = new TypeConverter<PufferStateTexture>(Deserialize, Serialize);
        public string name;
        public float? runTime;

        public PufferStateTexture(string name, float? runTime)
        {
            this.name = name;
            this.runTime = runTime;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<float?> runTime;
        }

        public static void Serialize(PufferStateTexture v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("run_time");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.runTime);
        }

        public static PufferStateTexture Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                runTime = new Field<float?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("PufferStateTexture", fieldName);
                }
            }
            return new PufferStateTexture(

                fields.name.Unwrap("PufferStateTexture", "name"),

                fields.runTime.Unwrap("PufferStateTexture", "runTime")

            );
        }
    }
}
