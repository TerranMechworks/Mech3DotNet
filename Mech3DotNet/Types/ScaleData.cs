using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ScaleData
    {
        public static readonly TypeConverter<ScaleData> Converter = new TypeConverter<ScaleData>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Vec3 value;
        public byte[] unk;

        public ScaleData(Mech3DotNet.Types.Types.Vec3 value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Vec3> value;
            public Field<byte[]> unk;
        }

        public static void Serialize(ScaleData v, Serializer s)
        {
            s.SerializeStruct("ScaleData", 2);
            s.SerializeFieldName("value");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.value);
            s.SerializeFieldName("unk");
            ((Action<byte[]>)s.SerializeBytes)(v.unk);
        }

        public static ScaleData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<Mech3DotNet.Types.Types.Vec3>(),
                unk = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ScaleData"))
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "unk":
                        fields.unk.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("ScaleData", fieldName);
                }
            }
            return new ScaleData(

                fields.value.Unwrap("ScaleData", "value"),

                fields.unk.Unwrap("ScaleData", "unk")

            );
        }
    }
}
