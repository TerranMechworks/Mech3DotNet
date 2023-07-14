using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZMetadataPm
    {
        public static readonly TypeConverter<GameZMetadataPm> Converter = new TypeConverter<GameZMetadataPm>(Deserialize, Serialize);
        public uint gamezHeaderUnk08;
        public int meshesArraySize;
        public uint nodeDataCount;
        public System.Collections.Generic.List<uint?> texturePtrs;

        public GameZMetadataPm(uint gamezHeaderUnk08, int meshesArraySize, uint nodeDataCount, System.Collections.Generic.List<uint?> texturePtrs)
        {
            this.gamezHeaderUnk08 = gamezHeaderUnk08;
            this.meshesArraySize = meshesArraySize;
            this.nodeDataCount = nodeDataCount;
            this.texturePtrs = texturePtrs;
        }

        private struct Fields
        {
            public Field<uint> gamezHeaderUnk08;
            public Field<int> meshesArraySize;
            public Field<uint> nodeDataCount;
            public Field<System.Collections.Generic.List<uint?>> texturePtrs;
        }

        public static void Serialize(GameZMetadataPm v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("gamez_header_unk08");
            ((Action<uint>)s.SerializeU32)(v.gamezHeaderUnk08);
            s.SerializeFieldName("meshes_array_size");
            ((Action<int>)s.SerializeI32)(v.meshesArraySize);
            s.SerializeFieldName("node_data_count");
            ((Action<uint>)s.SerializeU32)(v.nodeDataCount);
            s.SerializeFieldName("texture_ptrs");
            s.SerializeVec(s.SerializeValOption(((Action<uint>)s.SerializeU32)))(v.texturePtrs);
        }

        public static GameZMetadataPm Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                gamezHeaderUnk08 = new Field<uint>(),
                meshesArraySize = new Field<int>(),
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
                    case "meshes_array_size":
                        fields.meshesArraySize.Value = d.DeserializeI32();
                        break;
                    case "node_data_count":
                        fields.nodeDataCount.Value = d.DeserializeU32();
                        break;
                    case "texture_ptrs":
                        fields.texturePtrs.Value = d.DeserializeVec(d.DeserializeValOption(d.DeserializeU32))();
                        break;
                    default:
                        throw new UnknownFieldException("GameZMetadataPm", fieldName);
                }
            }
            return new GameZMetadataPm(

                fields.gamezHeaderUnk08.Unwrap("GameZMetadataPm", "gamezHeaderUnk08"),

                fields.meshesArraySize.Unwrap("GameZMetadataPm", "meshesArraySize"),

                fields.nodeDataCount.Unwrap("GameZMetadataPm", "nodeDataCount"),

                fields.texturePtrs.Unwrap("GameZMetadataPm", "texturePtrs")

            );
        }
    }
}
