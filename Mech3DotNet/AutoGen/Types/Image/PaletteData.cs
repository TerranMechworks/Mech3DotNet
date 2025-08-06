using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class PaletteData
    {
        public byte[] data;

        public PaletteData(byte[] data)
        {
            this.data = data;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<PaletteData> Converter = new TypeConverter<PaletteData>(Deserialize, Serialize);

        public static void Serialize(PaletteData v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("data");
            ((Action<byte[]>)s.SerializeBytes)(v.data);
        }

        private struct Fields
        {
            public Field<byte[]> data;
        }

        public static PaletteData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                data = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
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

        #endregion
    }
}
