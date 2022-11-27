using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Mw
{
    public sealed class World
    {
        public static readonly TypeConverter<World> Converter = new TypeConverter<World>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Nodes.Area area;
        public System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Partition>> partitions;
        public uint areaPartitionXCount;
        public uint areaPartitionYCount;
        public bool fudgeCount;
        public uint areaPartitionPtr;
        public uint virtPartitionPtr;
        public uint worldChildrenPtr;
        public uint worldChildValue;
        public uint worldLightsPtr;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint childrenArrayPtr;

        public World(string name, Mech3DotNet.Types.Nodes.Area area, System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Partition>> partitions, uint areaPartitionXCount, uint areaPartitionYCount, bool fudgeCount, uint areaPartitionPtr, uint virtPartitionPtr, uint worldChildrenPtr, uint worldChildValue, uint worldLightsPtr, System.Collections.Generic.List<uint> children, uint dataPtr, uint childrenArrayPtr)
        {
            this.name = name;
            this.area = area;
            this.partitions = partitions;
            this.areaPartitionXCount = areaPartitionXCount;
            this.areaPartitionYCount = areaPartitionYCount;
            this.fudgeCount = fudgeCount;
            this.areaPartitionPtr = areaPartitionPtr;
            this.virtPartitionPtr = virtPartitionPtr;
            this.worldChildrenPtr = worldChildrenPtr;
            this.worldChildValue = worldChildValue;
            this.worldLightsPtr = worldLightsPtr;
            this.children = children;
            this.dataPtr = dataPtr;
            this.childrenArrayPtr = childrenArrayPtr;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Nodes.Area> area;
            public Field<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Partition>>> partitions;
            public Field<uint> areaPartitionXCount;
            public Field<uint> areaPartitionYCount;
            public Field<bool> fudgeCount;
            public Field<uint> areaPartitionPtr;
            public Field<uint> virtPartitionPtr;
            public Field<uint> worldChildrenPtr;
            public Field<uint> worldChildValue;
            public Field<uint> worldLightsPtr;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<uint> dataPtr;
            public Field<uint> childrenArrayPtr;
        }

        public static void Serialize(Mech3DotNet.Types.Nodes.Mw.World v, Serializer s)
        {
            s.SerializeStruct("World", 14);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("area");
            s.Serialize(Mech3DotNet.Types.Nodes.Area.Converter)(v.area);
            s.SerializeFieldName("partitions");
            s.SerializeVec(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.Partition.Converter)))(v.partitions);
            s.SerializeFieldName("area_partition_x_count");
            ((Action<uint>)s.SerializeU32)(v.areaPartitionXCount);
            s.SerializeFieldName("area_partition_y_count");
            ((Action<uint>)s.SerializeU32)(v.areaPartitionYCount);
            s.SerializeFieldName("fudge_count");
            ((Action<bool>)s.SerializeBool)(v.fudgeCount);
            s.SerializeFieldName("area_partition_ptr");
            ((Action<uint>)s.SerializeU32)(v.areaPartitionPtr);
            s.SerializeFieldName("virt_partition_ptr");
            ((Action<uint>)s.SerializeU32)(v.virtPartitionPtr);
            s.SerializeFieldName("world_children_ptr");
            ((Action<uint>)s.SerializeU32)(v.worldChildrenPtr);
            s.SerializeFieldName("world_child_value");
            ((Action<uint>)s.SerializeU32)(v.worldChildValue);
            s.SerializeFieldName("world_lights_ptr");
            ((Action<uint>)s.SerializeU32)(v.worldLightsPtr);
            s.SerializeFieldName("children");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.children);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
            s.SerializeFieldName("children_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.childrenArrayPtr);
        }

        public static Mech3DotNet.Types.Nodes.Mw.World Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                area = new Field<Mech3DotNet.Types.Nodes.Area>(),
                partitions = new Field<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Partition>>>(),
                areaPartitionXCount = new Field<uint>(),
                areaPartitionYCount = new Field<uint>(),
                fudgeCount = new Field<bool>(),
                areaPartitionPtr = new Field<uint>(),
                virtPartitionPtr = new Field<uint>(),
                worldChildrenPtr = new Field<uint>(),
                worldChildValue = new Field<uint>(),
                worldLightsPtr = new Field<uint>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                dataPtr = new Field<uint>(),
                childrenArrayPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("World"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "area":
                        fields.area.Value = d.Deserialize(Mech3DotNet.Types.Nodes.Area.Converter)();
                        break;
                    case "partitions":
                        fields.partitions.Value = d.DeserializeVec(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.Partition.Converter)))();
                        break;
                    case "area_partition_x_count":
                        fields.areaPartitionXCount.Value = d.DeserializeU32();
                        break;
                    case "area_partition_y_count":
                        fields.areaPartitionYCount.Value = d.DeserializeU32();
                        break;
                    case "fudge_count":
                        fields.fudgeCount.Value = d.DeserializeBool();
                        break;
                    case "area_partition_ptr":
                        fields.areaPartitionPtr.Value = d.DeserializeU32();
                        break;
                    case "virt_partition_ptr":
                        fields.virtPartitionPtr.Value = d.DeserializeU32();
                        break;
                    case "world_children_ptr":
                        fields.worldChildrenPtr.Value = d.DeserializeU32();
                        break;
                    case "world_child_value":
                        fields.worldChildValue.Value = d.DeserializeU32();
                        break;
                    case "world_lights_ptr":
                        fields.worldLightsPtr.Value = d.DeserializeU32();
                        break;
                    case "children":
                        fields.children.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    case "children_array_ptr":
                        fields.childrenArrayPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("World", fieldName);
                }
            }
            return new World(

                fields.name.Unwrap("World", "name"),

                fields.area.Unwrap("World", "area"),

                fields.partitions.Unwrap("World", "partitions"),

                fields.areaPartitionXCount.Unwrap("World", "areaPartitionXCount"),

                fields.areaPartitionYCount.Unwrap("World", "areaPartitionYCount"),

                fields.fudgeCount.Unwrap("World", "fudgeCount"),

                fields.areaPartitionPtr.Unwrap("World", "areaPartitionPtr"),

                fields.virtPartitionPtr.Unwrap("World", "virtPartitionPtr"),

                fields.worldChildrenPtr.Unwrap("World", "worldChildrenPtr"),

                fields.worldChildValue.Unwrap("World", "worldChildValue"),

                fields.worldLightsPtr.Unwrap("World", "worldLightsPtr"),

                fields.children.Unwrap("World", "children"),

                fields.dataPtr.Unwrap("World", "dataPtr"),

                fields.childrenArrayPtr.Unwrap("World", "childrenArrayPtr")

            );
        }
    }
}
