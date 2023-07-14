using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class Object3d
    {
        public static readonly TypeConverter<Object3d> Converter = new TypeConverter<Object3d>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Nodes.Rc.Transformation transformation;
        public uint matrixSigns;
        public Mech3DotNet.Types.Nodes.NodeFlags flags;
        public uint zoneId;
        public Mech3DotNet.Types.Nodes.AreaPartition? areaPartition;
        public int meshIndex;
        public uint? parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public Mech3DotNet.Types.Nodes.BoundingBox unk116;
        public Mech3DotNet.Types.Nodes.BoundingBox unk140;
        public Mech3DotNet.Types.Nodes.BoundingBox unk164;

        public Object3d(string name, Mech3DotNet.Types.Nodes.Rc.Transformation transformation, uint matrixSigns, Mech3DotNet.Types.Nodes.NodeFlags flags, uint zoneId, Mech3DotNet.Types.Nodes.AreaPartition? areaPartition, int meshIndex, uint? parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Mech3DotNet.Types.Nodes.BoundingBox unk116, Mech3DotNet.Types.Nodes.BoundingBox unk140, Mech3DotNet.Types.Nodes.BoundingBox unk164)
        {
            this.name = name;
            this.transformation = transformation;
            this.matrixSigns = matrixSigns;
            this.flags = flags;
            this.zoneId = zoneId;
            this.areaPartition = areaPartition;
            this.meshIndex = meshIndex;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk116 = unk116;
            this.unk140 = unk140;
            this.unk164 = unk164;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Nodes.Rc.Transformation> transformation;
            public Field<uint> matrixSigns;
            public Field<Mech3DotNet.Types.Nodes.NodeFlags> flags;
            public Field<uint> zoneId;
            public Field<Mech3DotNet.Types.Nodes.AreaPartition?> areaPartition;
            public Field<int> meshIndex;
            public Field<uint?> parent;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<uint> dataPtr;
            public Field<uint> parentArrayPtr;
            public Field<uint> childrenArrayPtr;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk116;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk140;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk164;
        }

        public static void Serialize(Object3d v, Serializer s)
        {
            s.SerializeStruct(15);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("transformation");
            s.Serialize(Mech3DotNet.Types.Nodes.Rc.Transformation.Converter)(v.transformation);
            s.SerializeFieldName("matrix_signs");
            ((Action<uint>)s.SerializeU32)(v.matrixSigns);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)(v.flags);
            s.SerializeFieldName("zone_id");
            ((Action<uint>)s.SerializeU32)(v.zoneId);
            s.SerializeFieldName("area_partition");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Nodes.AreaPartitionConverter.Converter))(v.areaPartition);
            s.SerializeFieldName("mesh_index");
            ((Action<int>)s.SerializeI32)(v.meshIndex);
            s.SerializeFieldName("parent");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.parent);
            s.SerializeFieldName("children");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.children);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
            s.SerializeFieldName("parent_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentArrayPtr);
            s.SerializeFieldName("children_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.childrenArrayPtr);
            s.SerializeFieldName("unk116");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk116);
            s.SerializeFieldName("unk140");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk140);
            s.SerializeFieldName("unk164");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk164);
        }

        public static Object3d Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                transformation = new Field<Mech3DotNet.Types.Nodes.Rc.Transformation>(),
                matrixSigns = new Field<uint>(),
                flags = new Field<Mech3DotNet.Types.Nodes.NodeFlags>(),
                zoneId = new Field<uint>(),
                areaPartition = new Field<Mech3DotNet.Types.Nodes.AreaPartition?>(),
                meshIndex = new Field<int>(),
                parent = new Field<uint?>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                dataPtr = new Field<uint>(),
                parentArrayPtr = new Field<uint>(),
                childrenArrayPtr = new Field<uint>(),
                unk116 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk140 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk164 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "transformation":
                        fields.transformation.Value = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.Transformation.Converter)();
                        break;
                    case "matrix_signs":
                        fields.matrixSigns.Value = d.DeserializeU32();
                        break;
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)();
                        break;
                    case "zone_id":
                        fields.zoneId.Value = d.DeserializeU32();
                        break;
                    case "area_partition":
                        fields.areaPartition.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Nodes.AreaPartitionConverter.Converter))();
                        break;
                    case "mesh_index":
                        fields.meshIndex.Value = d.DeserializeI32();
                        break;
                    case "parent":
                        fields.parent.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "children":
                        fields.children.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    case "parent_array_ptr":
                        fields.parentArrayPtr.Value = d.DeserializeU32();
                        break;
                    case "children_array_ptr":
                        fields.childrenArrayPtr.Value = d.DeserializeU32();
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
                    default:
                        throw new UnknownFieldException("Object3d", fieldName);
                }
            }
            return new Object3d(

                fields.name.Unwrap("Object3d", "name"),

                fields.transformation.Unwrap("Object3d", "transformation"),

                fields.matrixSigns.Unwrap("Object3d", "matrixSigns"),

                fields.flags.Unwrap("Object3d", "flags"),

                fields.zoneId.Unwrap("Object3d", "zoneId"),

                fields.areaPartition.Unwrap("Object3d", "areaPartition"),

                fields.meshIndex.Unwrap("Object3d", "meshIndex"),

                fields.parent.Unwrap("Object3d", "parent"),

                fields.children.Unwrap("Object3d", "children"),

                fields.dataPtr.Unwrap("Object3d", "dataPtr"),

                fields.parentArrayPtr.Unwrap("Object3d", "parentArrayPtr"),

                fields.childrenArrayPtr.Unwrap("Object3d", "childrenArrayPtr"),

                fields.unk116.Unwrap("Object3d", "unk116"),

                fields.unk140.Unwrap("Object3d", "unk140"),

                fields.unk164.Unwrap("Object3d", "unk164")

            );
        }
    }
}
