using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZMetadata
    {
        public static readonly TypeConverter<GameZMetadata> Converter = new TypeConverter<GameZMetadata>(Deserialize, Serialize);
        public System.DateTime datetime;
        public short materialArraySize;
        public short modelArraySize;
        public short nodeArraySize;
        public int nodeLastFree;

        public GameZMetadata(System.DateTime datetime, short materialArraySize, short modelArraySize, short nodeArraySize, int nodeLastFree)
        {
            this.datetime = datetime;
            this.materialArraySize = materialArraySize;
            this.modelArraySize = modelArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeLastFree = nodeLastFree;
        }

        private struct Fields
        {
            public Field<System.DateTime> datetime;
            public Field<short> materialArraySize;
            public Field<short> modelArraySize;
            public Field<short> nodeArraySize;
            public Field<int> nodeLastFree;
        }

        public static void Serialize(GameZMetadata v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("datetime");
            ((Action<DateTime>)s.SerializeDateTime)(v.datetime);
            s.SerializeFieldName("material_array_size");
            ((Action<short>)s.SerializeI16)(v.materialArraySize);
            s.SerializeFieldName("model_array_size");
            ((Action<short>)s.SerializeI16)(v.modelArraySize);
            s.SerializeFieldName("node_array_size");
            ((Action<short>)s.SerializeI16)(v.nodeArraySize);
            s.SerializeFieldName("node_last_free");
            ((Action<int>)s.SerializeI32)(v.nodeLastFree);
        }

        public static GameZMetadata Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                datetime = new Field<System.DateTime>(),
                materialArraySize = new Field<short>(),
                modelArraySize = new Field<short>(),
                nodeArraySize = new Field<short>(),
                nodeLastFree = new Field<int>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "datetime":
                        fields.datetime.Value = d.DeserializeDateTime();
                        break;
                    case "material_array_size":
                        fields.materialArraySize.Value = d.DeserializeI16();
                        break;
                    case "model_array_size":
                        fields.modelArraySize.Value = d.DeserializeI16();
                        break;
                    case "node_array_size":
                        fields.nodeArraySize.Value = d.DeserializeI16();
                        break;
                    case "node_last_free":
                        fields.nodeLastFree.Value = d.DeserializeI32();
                        break;
                    default:
                        throw new UnknownFieldException("GameZMetadata", fieldName);
                }
            }
            return new GameZMetadata(

                fields.datetime.Unwrap("GameZMetadata", "datetime"),

                fields.materialArraySize.Unwrap("GameZMetadata", "materialArraySize"),

                fields.modelArraySize.Unwrap("GameZMetadata", "modelArraySize"),

                fields.nodeArraySize.Unwrap("GameZMetadata", "nodeArraySize"),

                fields.nodeLastFree.Unwrap("GameZMetadata", "nodeLastFree")

            );
        }
    }
}
