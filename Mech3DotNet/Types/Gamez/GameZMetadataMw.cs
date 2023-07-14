using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZMetadataMw
    {
        public static readonly TypeConverter<GameZMetadataMw> Converter = new TypeConverter<GameZMetadataMw>(Deserialize, Serialize);
        public int meshesArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;

        public GameZMetadataMw(int meshesArraySize, uint nodeArraySize, uint nodeDataCount)
        {
            this.meshesArraySize = meshesArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
        }

        private struct Fields
        {
            public Field<int> meshesArraySize;
            public Field<uint> nodeArraySize;
            public Field<uint> nodeDataCount;
        }

        public static void Serialize(GameZMetadataMw v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("meshes_array_size");
            ((Action<int>)s.SerializeI32)(v.meshesArraySize);
            s.SerializeFieldName("node_array_size");
            ((Action<uint>)s.SerializeU32)(v.nodeArraySize);
            s.SerializeFieldName("node_data_count");
            ((Action<uint>)s.SerializeU32)(v.nodeDataCount);
        }

        public static GameZMetadataMw Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                meshesArraySize = new Field<int>(),
                nodeArraySize = new Field<uint>(),
                nodeDataCount = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
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
                        throw new UnknownFieldException("GameZMetadataMw", fieldName);
                }
            }
            return new GameZMetadataMw(

                fields.meshesArraySize.Unwrap("GameZMetadataMw", "meshesArraySize"),

                fields.nodeArraySize.Unwrap("GameZMetadataMw", "nodeArraySize"),

                fields.nodeDataCount.Unwrap("GameZMetadataMw", "nodeDataCount")

            );
        }
    }
}
