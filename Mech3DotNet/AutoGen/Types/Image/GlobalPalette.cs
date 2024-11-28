using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class GlobalPalette
    {
        public static readonly TypeConverter<GlobalPalette> Converter = new TypeConverter<GlobalPalette>(Deserialize, Serialize);
        public uint index;
        public ushort count;

        public GlobalPalette(uint index, ushort count)
        {
            this.index = index;
            this.count = count;
        }

        private struct Fields
        {
            public Field<uint> index;
            public Field<ushort> count;
        }

        public static void Serialize(GlobalPalette v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("index");
            ((Action<uint>)s.SerializeU32)(v.index);
            s.SerializeFieldName("count");
            ((Action<ushort>)s.SerializeU16)(v.count);
        }

        public static GlobalPalette Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                index = new Field<uint>(),
                count = new Field<ushort>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "index":
                        fields.index.Value = d.DeserializeU32();
                        break;
                    case "count":
                        fields.count.Value = d.DeserializeU16();
                        break;
                    default:
                        throw new UnknownFieldException("GlobalPalette", fieldName);
                }
            }
            return new GlobalPalette(

                fields.index.Unwrap("GlobalPalette", "index"),

                fields.count.Unwrap("GlobalPalette", "count")

            );
        }
    }
}
