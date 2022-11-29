using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class PaletteData
    {
        public static readonly TypeConverter<PaletteData> Converter = new TypeConverter<PaletteData>(Deserialize, Serialize);
        public byte[] data;

        public PaletteData(byte[] data)
        {
            this.data = data;
        }

        private struct Fields
        {
            public Field<byte[]> data;
        }

        public static void Serialize(PaletteData v, Serializer s)
        {
            s.SerializeStruct("PaletteData", 1);
            s.SerializeFieldName("data");
            ((Action<byte[]>)s.SerializeBytes)(v.data);
        }

        public static PaletteData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                data = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct("PaletteData"))
            {
                switch (fieldName)
                {
                    case "data":
                        fields.data.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("PaletteData", fieldName);
                }
            }
            return new PaletteData(

                fields.data.Unwrap("PaletteData", "data")

            );
        }
    }
}
