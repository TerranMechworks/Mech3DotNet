using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class GlobalPalette
    {
        public static readonly TypeConverter<GlobalPalette> Converter = new TypeConverter<GlobalPalette>(Deserialize, Serialize);
        public int index;
        public ushort count;

        public GlobalPalette(int index, ushort count)
        {
            this.index = index;
            this.count = count;
        }

        private struct Fields
        {
            public Field<int> index;
            public Field<ushort> count;
        }

        public static void Serialize(Mech3DotNet.Types.Image.GlobalPalette v, Serializer s)
        {
            s.SerializeStruct("GlobalPalette", 2);
            s.SerializeFieldName("index");
            ((Action<int>)s.SerializeI32)(v.index);
            s.SerializeFieldName("count");
            ((Action<ushort>)s.SerializeU16)(v.count);
        }

        public static Mech3DotNet.Types.Image.GlobalPalette Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                index = new Field<int>(),
                count = new Field<ushort>(),
            };
            foreach (var fieldName in d.DeserializeStruct("GlobalPalette"))
            {
                switch (fieldName)
                {
                    case "index":
                        fields.index.Value = d.DeserializeI32();
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
