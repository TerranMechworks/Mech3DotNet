using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class TranslateData
    {
        public static readonly TypeConverter<TranslateData> Converter = new TypeConverter<TranslateData>(Deserialize, Serialize);
        public Mech3DotNet.Types.Vec3 value;
        public byte[] unk;

        public TranslateData(Mech3DotNet.Types.Vec3 value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Vec3> value;
            public Field<byte[]> unk;
        }

        public static void Serialize(TranslateData v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("value");
            s.Serialize(Mech3DotNet.Types.Vec3Converter.Converter)(v.value);
            s.SerializeFieldName("unk");
            ((Action<byte[]>)s.SerializeBytes)(v.unk);
        }

        public static TranslateData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<Mech3DotNet.Types.Vec3>(),
                unk = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.Deserialize(Mech3DotNet.Types.Vec3Converter.Converter)();
                        break;
                    case "unk":
                        fields.unk.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("TranslateData", fieldName);
                }
            }
            return new TranslateData(

                fields.value.Unwrap("TranslateData", "value"),

                fields.unk.Unwrap("TranslateData", "unk")

            );
        }
    }
}
