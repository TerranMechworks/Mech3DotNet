using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Pm
{
    public sealed class Object3dPm
    {
        public static readonly TypeConverter<Object3dPm> Converter = new TypeConverter<Object3dPm>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Nodes.Transformation? transformation;
        public uint matrixSigns;
        public Mech3DotNet.Types.Nodes.NodeFlags flags;
        public int meshIndex;
        public uint? parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public uint unk044;
        public uint unk112;
        public Mech3DotNet.Types.Nodes.BoundingBox unk116;
        public Mech3DotNet.Types.Nodes.BoundingBox unk140;
        public Mech3DotNet.Types.Nodes.BoundingBox unk164;

        public Object3dPm(string name, Mech3DotNet.Types.Nodes.Transformation? transformation, uint matrixSigns, Mech3DotNet.Types.Nodes.NodeFlags flags, int meshIndex, uint? parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, uint unk044, uint unk112, Mech3DotNet.Types.Nodes.BoundingBox unk116, Mech3DotNet.Types.Nodes.BoundingBox unk140, Mech3DotNet.Types.Nodes.BoundingBox unk164)
        {
            this.name = name;
            this.transformation = transformation;
            this.matrixSigns = matrixSigns;
            this.flags = flags;
            this.meshIndex = meshIndex;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk044 = unk044;
            this.unk112 = unk112;
            this.unk116 = unk116;
            this.unk140 = unk140;
            this.unk164 = unk164;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Nodes.Transformation?> transformation;
            public Field<uint> matrixSigns;
            public Field<Mech3DotNet.Types.Nodes.NodeFlags> flags;
            public Field<int> meshIndex;
            public Field<uint?> parent;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<uint> dataPtr;
            public Field<uint> parentArrayPtr;
            public Field<uint> childrenArrayPtr;
            public Field<uint> unk044;
            public Field<uint> unk112;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk116;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk140;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk164;
        }

        public static void Serialize(Object3dPm v, Serializer s)
        {
            s.SerializeStruct("Object3dPm", 15);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("transformation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Nodes.Transformation.Converter))(v.transformation);
            s.SerializeFieldName("matrix_signs");
            ((Action<uint>)s.SerializeU32)(v.matrixSigns);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)(v.flags);
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
            s.SerializeFieldName("unk044");
            ((Action<uint>)s.SerializeU32)(v.unk044);
            s.SerializeFieldName("unk112");
            ((Action<uint>)s.SerializeU32)(v.unk112);
            s.SerializeFieldName("unk116");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk116);
            s.SerializeFieldName("unk140");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk140);
            s.SerializeFieldName("unk164");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk164);
        }

        public static Object3dPm Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                transformation = new Field<Mech3DotNet.Types.Nodes.Transformation?>(),
                matrixSigns = new Field<uint>(),
                flags = new Field<Mech3DotNet.Types.Nodes.NodeFlags>(),
                meshIndex = new Field<int>(),
                parent = new Field<uint?>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                dataPtr = new Field<uint>(),
                parentArrayPtr = new Field<uint>(),
                childrenArrayPtr = new Field<uint>(),
                unk044 = new Field<uint>(),
                unk112 = new Field<uint>(),
                unk116 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk140 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk164 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Object3dPm"))
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
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)();
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
                    case "unk044":
                        fields.unk044.Value = d.DeserializeU32();
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
                    default:
                        throw new UnknownFieldException("Object3dPm", fieldName);
                }
            }
            return new Object3dPm(

                fields.name.Unwrap("Object3dPm", "name"),

                fields.transformation.Unwrap("Object3dPm", "transformation"),

                fields.matrixSigns.Unwrap("Object3dPm", "matrixSigns"),

                fields.flags.Unwrap("Object3dPm", "flags"),

                fields.meshIndex.Unwrap("Object3dPm", "meshIndex"),

                fields.parent.Unwrap("Object3dPm", "parent"),

                fields.children.Unwrap("Object3dPm", "children"),

                fields.dataPtr.Unwrap("Object3dPm", "dataPtr"),

                fields.parentArrayPtr.Unwrap("Object3dPm", "parentArrayPtr"),

                fields.childrenArrayPtr.Unwrap("Object3dPm", "childrenArrayPtr"),

                fields.unk044.Unwrap("Object3dPm", "unk044"),

                fields.unk112.Unwrap("Object3dPm", "unk112"),

                fields.unk116.Unwrap("Object3dPm", "unk116"),

                fields.unk140.Unwrap("Object3dPm", "unk140"),

                fields.unk164.Unwrap("Object3dPm", "unk164")

            );
        }
    }
}
