using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Node
    {
        public static readonly TypeConverter<Node> Converter = new TypeConverter<Node>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Gamez.Nodes.NodeFlags flags;
        public uint updateFlags;
        public sbyte zoneId;
        public short modelIndex;
        public Mech3DotNet.Types.Gamez.Nodes.Partition? areaPartition;
        public Mech3DotNet.Types.Gamez.Nodes.Partition? virtualPartition;
        public System.Collections.Generic.List<short> parentIndices;
        public System.Collections.Generic.List<short> childIndices;
        public Mech3DotNet.Types.Gamez.Nodes.ActiveBoundingBox activeBbox;
        public Mech3DotNet.Types.Gamez.Nodes.BoundingBox nodeBbox;
        public Mech3DotNet.Types.Gamez.Nodes.BoundingBox modelBbox;
        public Mech3DotNet.Types.Gamez.Nodes.BoundingBox childBbox;
        public int field192;
        public int field196;
        public int field200;
        public int field204;
        public Mech3DotNet.Types.Gamez.Nodes.NodeData data;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childArrayPtr;
        public uint index;

        public Node(string name, Mech3DotNet.Types.Gamez.Nodes.NodeFlags flags, uint updateFlags, sbyte zoneId, short modelIndex, Mech3DotNet.Types.Gamez.Nodes.Partition? areaPartition, Mech3DotNet.Types.Gamez.Nodes.Partition? virtualPartition, System.Collections.Generic.List<short> parentIndices, System.Collections.Generic.List<short> childIndices, Mech3DotNet.Types.Gamez.Nodes.ActiveBoundingBox activeBbox, Mech3DotNet.Types.Gamez.Nodes.BoundingBox nodeBbox, Mech3DotNet.Types.Gamez.Nodes.BoundingBox modelBbox, Mech3DotNet.Types.Gamez.Nodes.BoundingBox childBbox, int field192, int field196, int field200, int field204, Mech3DotNet.Types.Gamez.Nodes.NodeData data, uint dataPtr, uint parentArrayPtr, uint childArrayPtr, uint index)
        {
            this.name = name;
            this.flags = flags;
            this.updateFlags = updateFlags;
            this.zoneId = zoneId;
            this.modelIndex = modelIndex;
            this.areaPartition = areaPartition;
            this.virtualPartition = virtualPartition;
            this.parentIndices = parentIndices;
            this.childIndices = childIndices;
            this.activeBbox = activeBbox;
            this.nodeBbox = nodeBbox;
            this.modelBbox = modelBbox;
            this.childBbox = childBbox;
            this.field192 = field192;
            this.field196 = field196;
            this.field200 = field200;
            this.field204 = field204;
            this.data = data;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childArrayPtr = childArrayPtr;
            this.index = index;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Gamez.Nodes.NodeFlags> flags;
            public Field<uint> updateFlags;
            public Field<sbyte> zoneId;
            public Field<short> modelIndex;
            public Field<Mech3DotNet.Types.Gamez.Nodes.Partition?> areaPartition;
            public Field<Mech3DotNet.Types.Gamez.Nodes.Partition?> virtualPartition;
            public Field<System.Collections.Generic.List<short>> parentIndices;
            public Field<System.Collections.Generic.List<short>> childIndices;
            public Field<Mech3DotNet.Types.Gamez.Nodes.ActiveBoundingBox> activeBbox;
            public Field<Mech3DotNet.Types.Gamez.Nodes.BoundingBox> nodeBbox;
            public Field<Mech3DotNet.Types.Gamez.Nodes.BoundingBox> modelBbox;
            public Field<Mech3DotNet.Types.Gamez.Nodes.BoundingBox> childBbox;
            public Field<int> field192;
            public Field<int> field196;
            public Field<int> field200;
            public Field<int> field204;
            public Field<Mech3DotNet.Types.Gamez.Nodes.NodeData> data;
            public Field<uint> dataPtr;
            public Field<uint> parentArrayPtr;
            public Field<uint> childArrayPtr;
            public Field<uint> index;
        }

        public static void Serialize(Node v, Serializer s)
        {
            s.SerializeStruct(22);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.NodeFlagsConverter.Converter)(v.flags);
            s.SerializeFieldName("update_flags");
            ((Action<uint>)s.SerializeU32)(v.updateFlags);
            s.SerializeFieldName("zone_id");
            ((Action<sbyte>)s.SerializeI8)(v.zoneId);
            s.SerializeFieldName("model_index");
            ((Action<short>)s.SerializeI16)(v.modelIndex);
            s.SerializeFieldName("area_partition");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Partition.Converter))(v.areaPartition);
            s.SerializeFieldName("virtual_partition");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Partition.Converter))(v.virtualPartition);
            s.SerializeFieldName("parent_indices");
            s.SerializeVec(((Action<short>)s.SerializeI16))(v.parentIndices);
            s.SerializeFieldName("child_indices");
            s.SerializeVec(((Action<short>)s.SerializeI16))(v.childIndices);
            s.SerializeFieldName("active_bbox");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.ActiveBoundingBoxConverter.Converter)(v.activeBbox);
            s.SerializeFieldName("node_bbox");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.BoundingBox.Converter)(v.nodeBbox);
            s.SerializeFieldName("model_bbox");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.BoundingBox.Converter)(v.modelBbox);
            s.SerializeFieldName("child_bbox");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.BoundingBox.Converter)(v.childBbox);
            s.SerializeFieldName("field192");
            ((Action<int>)s.SerializeI32)(v.field192);
            s.SerializeFieldName("field196");
            ((Action<int>)s.SerializeI32)(v.field196);
            s.SerializeFieldName("field200");
            ((Action<int>)s.SerializeI32)(v.field200);
            s.SerializeFieldName("field204");
            ((Action<int>)s.SerializeI32)(v.field204);
            s.SerializeFieldName("data");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.NodeData.Converter)(v.data);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
            s.SerializeFieldName("parent_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentArrayPtr);
            s.SerializeFieldName("child_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.childArrayPtr);
            s.SerializeFieldName("index");
            ((Action<uint>)s.SerializeU32)(v.index);
        }

        public static Node Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                flags = new Field<Mech3DotNet.Types.Gamez.Nodes.NodeFlags>(),
                updateFlags = new Field<uint>(),
                zoneId = new Field<sbyte>(),
                modelIndex = new Field<short>(),
                areaPartition = new Field<Mech3DotNet.Types.Gamez.Nodes.Partition?>(),
                virtualPartition = new Field<Mech3DotNet.Types.Gamez.Nodes.Partition?>(),
                parentIndices = new Field<System.Collections.Generic.List<short>>(),
                childIndices = new Field<System.Collections.Generic.List<short>>(),
                activeBbox = new Field<Mech3DotNet.Types.Gamez.Nodes.ActiveBoundingBox>(),
                nodeBbox = new Field<Mech3DotNet.Types.Gamez.Nodes.BoundingBox>(),
                modelBbox = new Field<Mech3DotNet.Types.Gamez.Nodes.BoundingBox>(),
                childBbox = new Field<Mech3DotNet.Types.Gamez.Nodes.BoundingBox>(),
                field192 = new Field<int>(),
                field196 = new Field<int>(),
                field200 = new Field<int>(),
                field204 = new Field<int>(),
                data = new Field<Mech3DotNet.Types.Gamez.Nodes.NodeData>(),
                dataPtr = new Field<uint>(),
                parentArrayPtr = new Field<uint>(),
                childArrayPtr = new Field<uint>(),
                index = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.NodeFlagsConverter.Converter)();
                        break;
                    case "update_flags":
                        fields.updateFlags.Value = d.DeserializeU32();
                        break;
                    case "zone_id":
                        fields.zoneId.Value = d.DeserializeI8();
                        break;
                    case "model_index":
                        fields.modelIndex.Value = d.DeserializeI16();
                        break;
                    case "area_partition":
                        fields.areaPartition.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Partition.Converter))();
                        break;
                    case "virtual_partition":
                        fields.virtualPartition.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Partition.Converter))();
                        break;
                    case "parent_indices":
                        fields.parentIndices.Value = d.DeserializeVec(d.DeserializeI16)();
                        break;
                    case "child_indices":
                        fields.childIndices.Value = d.DeserializeVec(d.DeserializeI16)();
                        break;
                    case "active_bbox":
                        fields.activeBbox.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.ActiveBoundingBoxConverter.Converter)();
                        break;
                    case "node_bbox":
                        fields.nodeBbox.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.BoundingBox.Converter)();
                        break;
                    case "model_bbox":
                        fields.modelBbox.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.BoundingBox.Converter)();
                        break;
                    case "child_bbox":
                        fields.childBbox.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.BoundingBox.Converter)();
                        break;
                    case "field192":
                        fields.field192.Value = d.DeserializeI32();
                        break;
                    case "field196":
                        fields.field196.Value = d.DeserializeI32();
                        break;
                    case "field200":
                        fields.field200.Value = d.DeserializeI32();
                        break;
                    case "field204":
                        fields.field204.Value = d.DeserializeI32();
                        break;
                    case "data":
                        fields.data.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.NodeData.Converter)();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    case "parent_array_ptr":
                        fields.parentArrayPtr.Value = d.DeserializeU32();
                        break;
                    case "child_array_ptr":
                        fields.childArrayPtr.Value = d.DeserializeU32();
                        break;
                    case "index":
                        fields.index.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Node", fieldName);
                }
            }
            return new Node(

                fields.name.Unwrap("Node", "name"),

                fields.flags.Unwrap("Node", "flags"),

                fields.updateFlags.Unwrap("Node", "updateFlags"),

                fields.zoneId.Unwrap("Node", "zoneId"),

                fields.modelIndex.Unwrap("Node", "modelIndex"),

                fields.areaPartition.Unwrap("Node", "areaPartition"),

                fields.virtualPartition.Unwrap("Node", "virtualPartition"),

                fields.parentIndices.Unwrap("Node", "parentIndices"),

                fields.childIndices.Unwrap("Node", "childIndices"),

                fields.activeBbox.Unwrap("Node", "activeBbox"),

                fields.nodeBbox.Unwrap("Node", "nodeBbox"),

                fields.modelBbox.Unwrap("Node", "modelBbox"),

                fields.childBbox.Unwrap("Node", "childBbox"),

                fields.field192.Unwrap("Node", "field192"),

                fields.field196.Unwrap("Node", "field196"),

                fields.field200.Unwrap("Node", "field200"),

                fields.field204.Unwrap("Node", "field204"),

                fields.data.Unwrap("Node", "data"),

                fields.dataPtr.Unwrap("Node", "dataPtr"),

                fields.parentArrayPtr.Unwrap("Node", "parentArrayPtr"),

                fields.childArrayPtr.Unwrap("Node", "childArrayPtr"),

                fields.index.Unwrap("Node", "index")

            );
        }
    }
}
