using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZCsMetadata
    {
        public static readonly TypeConverter<GameZCsMetadata> Converter = new TypeConverter<GameZCsMetadata>(Deserialize, Serialize);
        public uint gamezHeaderUnk08;
        public short materialArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;
        public System.Collections.Generic.List<uint?> texturePtrs;

        public GameZCsMetadata(uint gamezHeaderUnk08, short materialArraySize, uint nodeArraySize, uint nodeDataCount, System.Collections.Generic.List<uint?> texturePtrs)
        {
            this.gamezHeaderUnk08 = gamezHeaderUnk08;
            this.materialArraySize = materialArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
            this.texturePtrs = texturePtrs;
        }

        private struct Fields
        {
            public Field<uint> gamezHeaderUnk08;
            public Field<short> materialArraySize;
            public Field<uint> nodeArraySize;
            public Field<uint> nodeDataCount;
            public Field<System.Collections.Generic.List<uint?>> texturePtrs;
        }

        public static void Serialize(GameZCsMetadata v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("gamez_header_unk08");
            ((Action<uint>)s.SerializeU32)(v.gamezHeaderUnk08);
            s.SerializeFieldName("material_array_size");
            ((Action<short>)s.SerializeI16)(v.materialArraySize);
            s.SerializeFieldName("node_array_size");
            ((Action<uint>)s.SerializeU32)(v.nodeArraySize);
            s.SerializeFieldName("node_data_count");
            ((Action<uint>)s.SerializeU32)(v.nodeDataCount);
            s.SerializeFieldName("texture_ptrs");
            s.SerializeVec(s.SerializeValOption(((Action<uint>)s.SerializeU32)))(v.texturePtrs);
        }

        public static GameZCsMetadata Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                gamezHeaderUnk08 = new Field<uint>(),
                materialArraySize = new Field<short>(),
                nodeArraySize = new Field<uint>(),
                nodeDataCount = new Field<uint>(),
                texturePtrs = new Field<System.Collections.Generic.List<uint?>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "gamez_header_unk08":
                        fields.gamezHeaderUnk08.Value = d.DeserializeU32();
                        break;
                    case "material_array_size":
                        fields.materialArraySize.Value = d.DeserializeI16();
                        break;
                    case "node_array_size":
                        fields.nodeArraySize.Value = d.DeserializeU32();
                        break;
                    case "node_data_count":
                        fields.nodeDataCount.Value = d.DeserializeU32();
                        break;
                    case "texture_ptrs":
                        fields.texturePtrs.Value = d.DeserializeVec(d.DeserializeValOption(d.DeserializeU32))();
                        break;
                    default:
                        throw new UnknownFieldException("GameZCsMetadata", fieldName);
                }
            }
            return new GameZCsMetadata(

                fields.gamezHeaderUnk08.Unwrap("GameZCsMetadata", "gamezHeaderUnk08"),

                fields.materialArraySize.Unwrap("GameZCsMetadata", "materialArraySize"),

                fields.nodeArraySize.Unwrap("GameZCsMetadata", "nodeArraySize"),

                fields.nodeDataCount.Unwrap("GameZCsMetadata", "nodeDataCount"),

                fields.texturePtrs.Unwrap("GameZCsMetadata", "texturePtrs")

            );
        }
    }
}
