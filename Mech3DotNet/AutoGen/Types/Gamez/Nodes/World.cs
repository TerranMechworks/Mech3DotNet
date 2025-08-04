using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class World
    {
        public static readonly TypeConverter<World> Converter = new TypeConverter<World>(Deserialize, Serialize);
        public Mech3DotNet.Types.Gamez.Nodes.WorldFog fog;
        public Mech3DotNet.Types.Gamez.Nodes.Area area;
        public bool virtualPartition;
        public byte partitionMaxDecFeatureCount;
        public System.Collections.Generic.List<short> lightIndices;
        public System.Collections.Generic.List<short> soundIndices;
        public System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartition>> partitions;
        public int unk;
        public Mech3DotNet.Types.Gamez.Nodes.WorldPtrs ptrs;

        public World(Mech3DotNet.Types.Gamez.Nodes.WorldFog fog, Mech3DotNet.Types.Gamez.Nodes.Area area, bool virtualPartition, byte partitionMaxDecFeatureCount, System.Collections.Generic.List<short> lightIndices, System.Collections.Generic.List<short> soundIndices, System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartition>> partitions, int unk, Mech3DotNet.Types.Gamez.Nodes.WorldPtrs ptrs)
        {
            this.fog = fog;
            this.area = area;
            this.virtualPartition = virtualPartition;
            this.partitionMaxDecFeatureCount = partitionMaxDecFeatureCount;
            this.lightIndices = lightIndices;
            this.soundIndices = soundIndices;
            this.partitions = partitions;
            this.unk = unk;
            this.ptrs = ptrs;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Gamez.Nodes.WorldFog> fog;
            public Field<Mech3DotNet.Types.Gamez.Nodes.Area> area;
            public Field<bool> virtualPartition;
            public Field<byte> partitionMaxDecFeatureCount;
            public Field<System.Collections.Generic.List<short>> lightIndices;
            public Field<System.Collections.Generic.List<short>> soundIndices;
            public Field<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartition>>> partitions;
            public Field<int> unk;
            public Field<Mech3DotNet.Types.Gamez.Nodes.WorldPtrs> ptrs;
        }

        public static void Serialize(World v, Serializer s)
        {
            s.SerializeStruct(9);
            s.SerializeFieldName("fog");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.WorldFog.Converter)(v.fog);
            s.SerializeFieldName("area");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Area.Converter)(v.area);
            s.SerializeFieldName("virtual_partition");
            ((Action<bool>)s.SerializeBool)(v.virtualPartition);
            s.SerializeFieldName("partition_max_dec_feature_count");
            ((Action<byte>)s.SerializeU8)(v.partitionMaxDecFeatureCount);
            s.SerializeFieldName("light_indices");
            s.SerializeVec(((Action<short>)s.SerializeI16))(v.lightIndices);
            s.SerializeFieldName("sound_indices");
            s.SerializeVec(((Action<short>)s.SerializeI16))(v.soundIndices);
            s.SerializeFieldName("partitions");
            s.SerializeVec(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Nodes.WorldPartition.Converter)))(v.partitions);
            s.SerializeFieldName("unk");
            ((Action<int>)s.SerializeI32)(v.unk);
            s.SerializeFieldName("ptrs");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.WorldPtrs.Converter)(v.ptrs);
        }

        public static World Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                fog = new Field<Mech3DotNet.Types.Gamez.Nodes.WorldFog>(),
                area = new Field<Mech3DotNet.Types.Gamez.Nodes.Area>(),
                virtualPartition = new Field<bool>(),
                partitionMaxDecFeatureCount = new Field<byte>(),
                lightIndices = new Field<System.Collections.Generic.List<short>>(),
                soundIndices = new Field<System.Collections.Generic.List<short>>(),
                partitions = new Field<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartition>>>(),
                unk = new Field<int>(),
                ptrs = new Field<Mech3DotNet.Types.Gamez.Nodes.WorldPtrs>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "fog":
                        fields.fog.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.WorldFog.Converter)();
                        break;
                    case "area":
                        fields.area.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Area.Converter)();
                        break;
                    case "virtual_partition":
                        fields.virtualPartition.Value = d.DeserializeBool();
                        break;
                    case "partition_max_dec_feature_count":
                        fields.partitionMaxDecFeatureCount.Value = d.DeserializeU8();
                        break;
                    case "light_indices":
                        fields.lightIndices.Value = d.DeserializeVec(d.DeserializeI16)();
                        break;
                    case "sound_indices":
                        fields.soundIndices.Value = d.DeserializeVec(d.DeserializeI16)();
                        break;
                    case "partitions":
                        fields.partitions.Value = d.DeserializeVec(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.WorldPartition.Converter)))();
                        break;
                    case "unk":
                        fields.unk.Value = d.DeserializeI32();
                        break;
                    case "ptrs":
                        fields.ptrs.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.WorldPtrs.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("World", fieldName);
                }
            }
            return new World(

                fields.fog.Unwrap("World", "fog"),

                fields.area.Unwrap("World", "area"),

                fields.virtualPartition.Unwrap("World", "virtualPartition"),

                fields.partitionMaxDecFeatureCount.Unwrap("World", "partitionMaxDecFeatureCount"),

                fields.lightIndices.Unwrap("World", "lightIndices"),

                fields.soundIndices.Unwrap("World", "soundIndices"),

                fields.partitions.Unwrap("World", "partitions"),

                fields.unk.Unwrap("World", "unk"),

                fields.ptrs.Unwrap("World", "ptrs")

            );
        }
    }
}
