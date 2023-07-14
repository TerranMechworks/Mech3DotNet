using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class World
    {
        public static readonly TypeConverter<World> Converter = new TypeConverter<World>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Nodes.Area area;
        public Mech3DotNet.Types.Color fogColor;
        public Mech3DotNet.Types.Range fogRange;
        public Mech3DotNet.Types.Range fogAltitude;
        public System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionPg>> partitions;
        public uint areaPartitionUnk;
        public uint virtPartitionXCount;
        public uint virtPartitionYCount;
        public uint areaPartitionPtr;
        public uint virtPartitionPtr;
        public uint worldChildrenPtr;
        public uint worldChildValue;
        public uint worldLightsPtr;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint childrenArrayPtr;

        public World(string name, Mech3DotNet.Types.Nodes.Area area, Mech3DotNet.Types.Color fogColor, Mech3DotNet.Types.Range fogRange, Mech3DotNet.Types.Range fogAltitude, System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionPg>> partitions, uint areaPartitionUnk, uint virtPartitionXCount, uint virtPartitionYCount, uint areaPartitionPtr, uint virtPartitionPtr, uint worldChildrenPtr, uint worldChildValue, uint worldLightsPtr, System.Collections.Generic.List<uint> children, uint dataPtr, uint childrenArrayPtr)
        {
            this.name = name;
            this.area = area;
            this.fogColor = fogColor;
            this.fogRange = fogRange;
            this.fogAltitude = fogAltitude;
            this.partitions = partitions;
            this.areaPartitionUnk = areaPartitionUnk;
            this.virtPartitionXCount = virtPartitionXCount;
            this.virtPartitionYCount = virtPartitionYCount;
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
            public Field<Mech3DotNet.Types.Color> fogColor;
            public Field<Mech3DotNet.Types.Range> fogRange;
            public Field<Mech3DotNet.Types.Range> fogAltitude;
            public Field<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionPg>>> partitions;
            public Field<uint> areaPartitionUnk;
            public Field<uint> virtPartitionXCount;
            public Field<uint> virtPartitionYCount;
            public Field<uint> areaPartitionPtr;
            public Field<uint> virtPartitionPtr;
            public Field<uint> worldChildrenPtr;
            public Field<uint> worldChildValue;
            public Field<uint> worldLightsPtr;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<uint> dataPtr;
            public Field<uint> childrenArrayPtr;
        }

        public static void Serialize(World v, Serializer s)
        {
            s.SerializeStruct(17);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("area");
            s.Serialize(Mech3DotNet.Types.Nodes.AreaConverter.Converter)(v.area);
            s.SerializeFieldName("fog_color");
            s.Serialize(Mech3DotNet.Types.ColorConverter.Converter)(v.fogColor);
            s.SerializeFieldName("fog_range");
            s.Serialize(Mech3DotNet.Types.RangeConverter.Converter)(v.fogRange);
            s.SerializeFieldName("fog_altitude");
            s.Serialize(Mech3DotNet.Types.RangeConverter.Converter)(v.fogAltitude);
            s.SerializeFieldName("partitions");
            s.SerializeVec(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.PartitionPg.Converter)))(v.partitions);
            s.SerializeFieldName("area_partition_unk");
            ((Action<uint>)s.SerializeU32)(v.areaPartitionUnk);
            s.SerializeFieldName("virt_partition_x_count");
            ((Action<uint>)s.SerializeU32)(v.virtPartitionXCount);
            s.SerializeFieldName("virt_partition_y_count");
            ((Action<uint>)s.SerializeU32)(v.virtPartitionYCount);
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

        public static World Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                area = new Field<Mech3DotNet.Types.Nodes.Area>(),
                fogColor = new Field<Mech3DotNet.Types.Color>(),
                fogRange = new Field<Mech3DotNet.Types.Range>(),
                fogAltitude = new Field<Mech3DotNet.Types.Range>(),
                partitions = new Field<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionPg>>>(),
                areaPartitionUnk = new Field<uint>(),
                virtPartitionXCount = new Field<uint>(),
                virtPartitionYCount = new Field<uint>(),
                areaPartitionPtr = new Field<uint>(),
                virtPartitionPtr = new Field<uint>(),
                worldChildrenPtr = new Field<uint>(),
                worldChildValue = new Field<uint>(),
                worldLightsPtr = new Field<uint>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                dataPtr = new Field<uint>(),
                childrenArrayPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "area":
                        fields.area.Value = d.Deserialize(Mech3DotNet.Types.Nodes.AreaConverter.Converter)();
                        break;
                    case "fog_color":
                        fields.fogColor.Value = d.Deserialize(Mech3DotNet.Types.ColorConverter.Converter)();
                        break;
                    case "fog_range":
                        fields.fogRange.Value = d.Deserialize(Mech3DotNet.Types.RangeConverter.Converter)();
                        break;
                    case "fog_altitude":
                        fields.fogAltitude.Value = d.Deserialize(Mech3DotNet.Types.RangeConverter.Converter)();
                        break;
                    case "partitions":
                        fields.partitions.Value = d.DeserializeVec(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.PartitionPg.Converter)))();
                        break;
                    case "area_partition_unk":
                        fields.areaPartitionUnk.Value = d.DeserializeU32();
                        break;
                    case "virt_partition_x_count":
                        fields.virtPartitionXCount.Value = d.DeserializeU32();
                        break;
                    case "virt_partition_y_count":
                        fields.virtPartitionYCount.Value = d.DeserializeU32();
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

                fields.fogColor.Unwrap("World", "fogColor"),

                fields.fogRange.Unwrap("World", "fogRange"),

                fields.fogAltitude.Unwrap("World", "fogAltitude"),

                fields.partitions.Unwrap("World", "partitions"),

                fields.areaPartitionUnk.Unwrap("World", "areaPartitionUnk"),

                fields.virtPartitionXCount.Unwrap("World", "virtPartitionXCount"),

                fields.virtPartitionYCount.Unwrap("World", "virtPartitionYCount"),

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
