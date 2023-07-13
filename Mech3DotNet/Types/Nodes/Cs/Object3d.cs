using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Cs
{
    public sealed class Object3d
    {
        public static readonly TypeConverter<Object3d> Converter = new TypeConverter<Object3d>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Nodes.Transformation? transformation;
        public uint matrixSigns;
        public uint rotationSigns;
        public uint flags;
        public uint unk040;
        public uint unk044;
        public uint zoneId;
        public uint dataPtr;
        public int meshIndex;
        public Mech3DotNet.Types.Nodes.Pm.AreaPartitionPm? areaPartition;
        public uint? parent;
        public uint parentArrayPtr;
        public System.Collections.Generic.List<uint> children;
        public uint childrenArrayPtr;
        public uint unk112;
        public Mech3DotNet.Types.Nodes.BoundingBox unk116;
        public Mech3DotNet.Types.Nodes.BoundingBox unk140;
        public Mech3DotNet.Types.Nodes.BoundingBox unk164;
        public uint nodeIndex;

        public Object3d(string name, Mech3DotNet.Types.Nodes.Transformation? transformation, uint matrixSigns, uint rotationSigns, uint flags, uint unk040, uint unk044, uint zoneId, uint dataPtr, int meshIndex, Mech3DotNet.Types.Nodes.Pm.AreaPartitionPm? areaPartition, uint? parent, uint parentArrayPtr, System.Collections.Generic.List<uint> children, uint childrenArrayPtr, uint unk112, Mech3DotNet.Types.Nodes.BoundingBox unk116, Mech3DotNet.Types.Nodes.BoundingBox unk140, Mech3DotNet.Types.Nodes.BoundingBox unk164, uint nodeIndex)
        {
            this.name = name;
            this.transformation = transformation;
            this.matrixSigns = matrixSigns;
            this.rotationSigns = rotationSigns;
            this.flags = flags;
            this.unk040 = unk040;
            this.unk044 = unk044;
            this.zoneId = zoneId;
            this.dataPtr = dataPtr;
            this.meshIndex = meshIndex;
            this.areaPartition = areaPartition;
            this.parent = parent;
            this.parentArrayPtr = parentArrayPtr;
            this.children = children;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk112 = unk112;
            this.unk116 = unk116;
            this.unk140 = unk140;
            this.unk164 = unk164;
            this.nodeIndex = nodeIndex;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Nodes.Transformation?> transformation;
            public Field<uint> matrixSigns;
            public Field<uint> rotationSigns;
            public Field<uint> flags;
            public Field<uint> unk040;
            public Field<uint> unk044;
            public Field<uint> zoneId;
            public Field<uint> dataPtr;
            public Field<int> meshIndex;
            public Field<Mech3DotNet.Types.Nodes.Pm.AreaPartitionPm?> areaPartition;
            public Field<uint?> parent;
            public Field<uint> parentArrayPtr;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<uint> childrenArrayPtr;
            public Field<uint> unk112;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk116;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk140;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk164;
            public Field<uint> nodeIndex;
        }

        public static void Serialize(Object3d v, Serializer s)
        {
            s.SerializeStruct(20);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("transformation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Nodes.Transformation.Converter))(v.transformation);
            s.SerializeFieldName("matrix_signs");
            ((Action<uint>)s.SerializeU32)(v.matrixSigns);
            s.SerializeFieldName("rotation_signs");
            ((Action<uint>)s.SerializeU32)(v.rotationSigns);
            s.SerializeFieldName("flags");
            ((Action<uint>)s.SerializeU32)(v.flags);
            s.SerializeFieldName("unk040");
            ((Action<uint>)s.SerializeU32)(v.unk040);
            s.SerializeFieldName("unk044");
            ((Action<uint>)s.SerializeU32)(v.unk044);
            s.SerializeFieldName("zone_id");
            ((Action<uint>)s.SerializeU32)(v.zoneId);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
            s.SerializeFieldName("mesh_index");
            ((Action<int>)s.SerializeI32)(v.meshIndex);
            s.SerializeFieldName("area_partition");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Nodes.Pm.AreaPartitionPm.Converter))(v.areaPartition);
            s.SerializeFieldName("parent");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.parent);
            s.SerializeFieldName("parent_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentArrayPtr);
            s.SerializeFieldName("children");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.children);
            s.SerializeFieldName("children_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.childrenArrayPtr);
            s.SerializeFieldName("unk112");
            ((Action<uint>)s.SerializeU32)(v.unk112);
            s.SerializeFieldName("unk116");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk116);
            s.SerializeFieldName("unk140");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk140);
            s.SerializeFieldName("unk164");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk164);
            s.SerializeFieldName("node_index");
            ((Action<uint>)s.SerializeU32)(v.nodeIndex);
        }

        public static Object3d Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                transformation = new Field<Mech3DotNet.Types.Nodes.Transformation?>(),
                matrixSigns = new Field<uint>(),
                rotationSigns = new Field<uint>(),
                flags = new Field<uint>(),
                unk040 = new Field<uint>(),
                unk044 = new Field<uint>(),
                zoneId = new Field<uint>(),
                dataPtr = new Field<uint>(),
                meshIndex = new Field<int>(),
                areaPartition = new Field<Mech3DotNet.Types.Nodes.Pm.AreaPartitionPm?>(),
                parent = new Field<uint?>(),
                parentArrayPtr = new Field<uint>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                childrenArrayPtr = new Field<uint>(),
                unk112 = new Field<uint>(),
                unk116 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk140 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk164 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                nodeIndex = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "transformation":
                        fields.transformation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Nodes.Transformation.Converter))();
                        break;
                    case "matrix_signs":
                        fields.matrixSigns.Value = d.DeserializeU32();
                        break;
                    case "rotation_signs":
                        fields.rotationSigns.Value = d.DeserializeU32();
                        break;
                    case "flags":
                        fields.flags.Value = d.DeserializeU32();
                        break;
                    case "unk040":
                        fields.unk040.Value = d.DeserializeU32();
                        break;
                    case "unk044":
                        fields.unk044.Value = d.DeserializeU32();
                        break;
                    case "zone_id":
                        fields.zoneId.Value = d.DeserializeU32();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    case "mesh_index":
                        fields.meshIndex.Value = d.DeserializeI32();
                        break;
                    case "area_partition":
                        fields.areaPartition.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Nodes.Pm.AreaPartitionPm.Converter))();
                        break;
                    case "parent":
                        fields.parent.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "parent_array_ptr":
                        fields.parentArrayPtr.Value = d.DeserializeU32();
                        break;
                    case "children":
                        fields.children.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "children_array_ptr":
                        fields.childrenArrayPtr.Value = d.DeserializeU32();
                        break;
                    case "unk112":
                        fields.unk112.Value = d.DeserializeU32();
                        break;
                    case "unk116":
                        fields.unk116.Value = d.Deserialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)();
                        break;
                    case "unk140":
                        fields.unk140.Value = d.Deserialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)();
                        break;
                    case "unk164":
                        fields.unk164.Value = d.Deserialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)();
                        break;
                    case "node_index":
                        fields.nodeIndex.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Object3d", fieldName);
                }
            }
            return new Object3d(

                fields.name.Unwrap("Object3d", "name"),

                fields.transformation.Unwrap("Object3d", "transformation"),

                fields.matrixSigns.Unwrap("Object3d", "matrixSigns"),

                fields.rotationSigns.Unwrap("Object3d", "rotationSigns"),

                fields.flags.Unwrap("Object3d", "flags"),

                fields.unk040.Unwrap("Object3d", "unk040"),

                fields.unk044.Unwrap("Object3d", "unk044"),

                fields.zoneId.Unwrap("Object3d", "zoneId"),

                fields.dataPtr.Unwrap("Object3d", "dataPtr"),

                fields.meshIndex.Unwrap("Object3d", "meshIndex"),

                fields.areaPartition.Unwrap("Object3d", "areaPartition"),

                fields.parent.Unwrap("Object3d", "parent"),

                fields.parentArrayPtr.Unwrap("Object3d", "parentArrayPtr"),

                fields.children.Unwrap("Object3d", "children"),

                fields.childrenArrayPtr.Unwrap("Object3d", "childrenArrayPtr"),

                fields.unk112.Unwrap("Object3d", "unk112"),

                fields.unk116.Unwrap("Object3d", "unk116"),

                fields.unk140.Unwrap("Object3d", "unk140"),

                fields.unk164.Unwrap("Object3d", "unk164"),

                fields.nodeIndex.Unwrap("Object3d", "nodeIndex")

            );
        }
    }
}
