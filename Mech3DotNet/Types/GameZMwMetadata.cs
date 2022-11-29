using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZMwMetadata
    {
        public static readonly TypeConverter<GameZMwMetadata> Converter = new TypeConverter<GameZMwMetadata>(Deserialize, Serialize);
        public short materialArraySize;
        public int meshesArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;

        public GameZMwMetadata(short materialArraySize, int meshesArraySize, uint nodeArraySize, uint nodeDataCount)
        {
            this.materialArraySize = materialArraySize;
            this.meshesArraySize = meshesArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
        }

        private struct Fields
        {
            public Field<short> materialArraySize;
            public Field<int> meshesArraySize;
            public Field<uint> nodeArraySize;
            public Field<uint> nodeDataCount;
        }

        public static void Serialize(GameZMwMetadata v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("material_array_size");
            ((Action<short>)s.SerializeI16)(v.materialArraySize);
            s.SerializeFieldName("meshes_array_size");
            ((Action<int>)s.SerializeI32)(v.meshesArraySize);
            s.SerializeFieldName("node_array_size");
            ((Action<uint>)s.SerializeU32)(v.nodeArraySize);
            s.SerializeFieldName("node_data_count");
            ((Action<uint>)s.SerializeU32)(v.nodeDataCount);
        }

        public static GameZMwMetadata Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                materialArraySize = new Field<short>(),
                meshesArraySize = new Field<int>(),
                nodeArraySize = new Field<uint>(),
                nodeDataCount = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "material_array_size":
                        fields.materialArraySize.Value = d.DeserializeI16();
                        break;
                    case "meshes_array_size":
                        fields.meshesArraySize.Value = d.DeserializeI32();
                        break;
                    case "node_array_size":
                        fields.nodeArraySize.Value = d.DeserializeU32();
                        break;
                    case "node_data_count":
                        fields.nodeDataCount.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("GameZMwMetadata", fieldName);
                }
            }
            return new GameZMwMetadata(

                fields.materialArraySize.Unwrap("GameZMwMetadata", "materialArraySize"),

                fields.meshesArraySize.Unwrap("GameZMwMetadata", "meshesArraySize"),

                fields.nodeArraySize.Unwrap("GameZMwMetadata", "nodeArraySize"),

                fields.nodeDataCount.Unwrap("GameZMwMetadata", "nodeDataCount")

            );
        }
    }
}
