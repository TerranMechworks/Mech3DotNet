using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class RotateData
    {
        public static readonly TypeConverter<RotateData> Converter = new TypeConverter<RotateData>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Quaternion value;
        public byte[] unk;

        public RotateData(Mech3DotNet.Types.Types.Quaternion value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Quaternion> value;
            public Field<byte[]> unk;
        }

        public static void Serialize(RotateData v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("value");
            s.Serialize(Mech3DotNet.Types.Types.QuaternionConverter.Converter)(v.value);
            s.SerializeFieldName("unk");
            ((Action<byte[]>)s.SerializeBytes)(v.unk);
        }

        public static RotateData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<Mech3DotNet.Types.Types.Quaternion>(),
                unk = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.Deserialize(Mech3DotNet.Types.Types.QuaternionConverter.Converter)();
                        break;
                    case "unk":
                        fields.unk.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("RotateData", fieldName);
                }
            }
            return new RotateData(

                fields.value.Unwrap("RotateData", "value"),

                fields.unk.Unwrap("RotateData", "unk")

            );
        }
    }
}
