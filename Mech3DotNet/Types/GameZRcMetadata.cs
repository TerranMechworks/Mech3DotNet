using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZRcMetadata
    {
        public static readonly TypeConverter<GameZRcMetadata> Converter = new TypeConverter<GameZRcMetadata>(Deserialize, Serialize);
        public short materialArraySize;
        public int meshesArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;

        public GameZRcMetadata(short materialArraySize, int meshesArraySize, uint nodeArraySize, uint nodeDataCount)
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

        public static void Serialize(GameZRcMetadata v, Serializer s)
        {
            s.SerializeStruct("GameZRcMetadata", 4);
            s.SerializeFieldName("material_array_size");
            ((Action<short>)s.SerializeI16)(v.materialArraySize);
            s.SerializeFieldName("meshes_array_size");
            ((Action<int>)s.SerializeI32)(v.meshesArraySize);
            s.SerializeFieldName("node_array_size");
            ((Action<uint>)s.SerializeU32)(v.nodeArraySize);
            s.SerializeFieldName("node_data_count");
            ((Action<uint>)s.SerializeU32)(v.nodeDataCount);
        }

        public static GameZRcMetadata Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                materialArraySize = new Field<short>(),
                meshesArraySize = new Field<int>(),
                nodeArraySize = new Field<uint>(),
                nodeDataCount = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("GameZRcMetadata"))
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
                        throw new UnknownFieldException("GameZRcMetadata", fieldName);
                }
            }
            return new GameZRcMetadata(

                fields.materialArraySize.Unwrap("GameZRcMetadata", "materialArraySize"),

                fields.meshesArraySize.Unwrap("GameZRcMetadata", "meshesArraySize"),

                fields.nodeArraySize.Unwrap("GameZRcMetadata", "nodeArraySize"),

                fields.nodeDataCount.Unwrap("GameZRcMetadata", "nodeDataCount")

            );
        }
    }
}
