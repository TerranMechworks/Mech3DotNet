using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class WorldPtrs
    {
        public uint areaPartitionPtr;
        public uint virtPartitionPtr;
        public uint lightNodesPtr;
        public uint lightDataPtr;
        public uint soundNodesPtr;
        public uint soundDataPtr;

        public WorldPtrs(uint areaPartitionPtr, uint virtPartitionPtr, uint lightNodesPtr, uint lightDataPtr, uint soundNodesPtr, uint soundDataPtr)
        {
            this.areaPartitionPtr = areaPartitionPtr;
            this.virtPartitionPtr = virtPartitionPtr;
            this.lightNodesPtr = lightNodesPtr;
            this.lightDataPtr = lightDataPtr;
            this.soundNodesPtr = soundNodesPtr;
            this.soundDataPtr = soundDataPtr;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<WorldPtrs> Converter = new TypeConverter<WorldPtrs>(Deserialize, Serialize);

        public static void Serialize(WorldPtrs v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("area_partition_ptr");
            ((Action<uint>)s.SerializeU32)(v.areaPartitionPtr);
            s.SerializeFieldName("virt_partition_ptr");
            ((Action<uint>)s.SerializeU32)(v.virtPartitionPtr);
            s.SerializeFieldName("light_nodes_ptr");
            ((Action<uint>)s.SerializeU32)(v.lightNodesPtr);
            s.SerializeFieldName("light_data_ptr");
            ((Action<uint>)s.SerializeU32)(v.lightDataPtr);
            s.SerializeFieldName("sound_nodes_ptr");
            ((Action<uint>)s.SerializeU32)(v.soundNodesPtr);
            s.SerializeFieldName("sound_data_ptr");
            ((Action<uint>)s.SerializeU32)(v.soundDataPtr);
        }

        private struct Fields
        {
            public Field<uint> areaPartitionPtr;
            public Field<uint> virtPartitionPtr;
            public Field<uint> lightNodesPtr;
            public Field<uint> lightDataPtr;
            public Field<uint> soundNodesPtr;
            public Field<uint> soundDataPtr;
        }

        public static WorldPtrs Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                areaPartitionPtr = new Field<uint>(),
                virtPartitionPtr = new Field<uint>(),
                lightNodesPtr = new Field<uint>(),
                lightDataPtr = new Field<uint>(),
                soundNodesPtr = new Field<uint>(),
                soundDataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "area_partition_ptr":
                        fields.areaPartitionPtr.Value = d.DeserializeU32();
                        break;
                    case "virt_partition_ptr":
                        fields.virtPartitionPtr.Value = d.DeserializeU32();
                        break;
                    case "light_nodes_ptr":
                        fields.lightNodesPtr.Value = d.DeserializeU32();
                        break;
                    case "light_data_ptr":
                        fields.lightDataPtr.Value = d.DeserializeU32();
                        break;
                    case "sound_nodes_ptr":
                        fields.soundNodesPtr.Value = d.DeserializeU32();
                        break;
                    case "sound_data_ptr":
                        fields.soundDataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("WorldPtrs", fieldName);
                }
            }
            return new WorldPtrs(

                fields.areaPartitionPtr.Unwrap("WorldPtrs", "areaPartitionPtr"),

                fields.virtPartitionPtr.Unwrap("WorldPtrs", "virtPartitionPtr"),

                fields.lightNodesPtr.Unwrap("WorldPtrs", "lightNodesPtr"),

                fields.lightDataPtr.Unwrap("WorldPtrs", "lightDataPtr"),

                fields.soundNodesPtr.Unwrap("WorldPtrs", "soundNodesPtr"),

                fields.soundDataPtr.Unwrap("WorldPtrs", "soundDataPtr")

            );
        }

        #endregion
    }
}
