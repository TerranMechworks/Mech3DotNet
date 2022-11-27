using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Pm
{
    public sealed class LodPm
    {
        public static readonly TypeConverter<LodPm> Converter = new TypeConverter<LodPm>(Deserialize, Serialize);
        public string name;
        public bool level;
        public Mech3DotNet.Types.Types.Range range;
        public float unk64;
        public float unk72;
        public uint parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public Mech3DotNet.Types.Nodes.BoundingBox unk164;

        public LodPm(string name, bool level, Mech3DotNet.Types.Types.Range range, float unk64, float unk72, uint parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Mech3DotNet.Types.Nodes.BoundingBox unk164)
        {
            this.name = name;
            this.level = level;
            this.range = range;
            this.unk64 = unk64;
            this.unk72 = unk72;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk164 = unk164;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> level;
            public Field<Mech3DotNet.Types.Types.Range> range;
            public Field<float> unk64;
            public Field<float> unk72;
            public Field<uint> parent;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<uint> dataPtr;
            public Field<uint> parentArrayPtr;
            public Field<uint> childrenArrayPtr;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk164;
        }

        public static void Serialize(Mech3DotNet.Types.Nodes.Pm.LodPm v, Serializer s)
        {
            s.SerializeStruct("LodPm", 11);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("level");
            ((Action<bool>)s.SerializeBool)(v.level);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Types.Range.Converter)(v.range);
            s.SerializeFieldName("unk64");
            ((Action<float>)s.SerializeF32)(v.unk64);
            s.SerializeFieldName("unk72");
            ((Action<float>)s.SerializeF32)(v.unk72);
            s.SerializeFieldName("parent");
            ((Action<uint>)s.SerializeU32)(v.parent);
            s.SerializeFieldName("children");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.children);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
            s.SerializeFieldName("parent_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentArrayPtr);
            s.SerializeFieldName("children_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.childrenArrayPtr);
            s.SerializeFieldName("unk164");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk164);
        }

        public static Mech3DotNet.Types.Nodes.Pm.LodPm Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                level = new Field<bool>(),
                range = new Field<Mech3DotNet.Types.Types.Range>(),
                unk64 = new Field<float>(),
                unk72 = new Field<float>(),
                parent = new Field<uint>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                dataPtr = new Field<uint>(),
                parentArrayPtr = new Field<uint>(),
                childrenArrayPtr = new Field<uint>(),
                unk164 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
            };
            foreach (var fieldName in d.DeserializeStruct("LodPm"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "level":
                        fields.level.Value = d.DeserializeBool();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Types.Range.Converter)();
                        break;
                    case "unk64":
                        fields.unk64.Value = d.DeserializeF32();
                        break;
                    case "unk72":
                        fields.unk72.Value = d.DeserializeF32();
                        break;
                    case "parent":
                        fields.parent.Value = d.DeserializeU32();
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
                    case "unk164":
                        fields.unk164.Value = d.Deserialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("LodPm", fieldName);
                }
            }
            return new LodPm(

                fields.name.Unwrap("LodPm", "name"),

                fields.level.Unwrap("LodPm", "level"),

                fields.range.Unwrap("LodPm", "range"),

                fields.unk64.Unwrap("LodPm", "unk64"),

                fields.unk72.Unwrap("LodPm", "unk72"),

                fields.parent.Unwrap("LodPm", "parent"),

                fields.children.Unwrap("LodPm", "children"),

                fields.dataPtr.Unwrap("LodPm", "dataPtr"),

                fields.parentArrayPtr.Unwrap("LodPm", "parentArrayPtr"),

                fields.childrenArrayPtr.Unwrap("LodPm", "childrenArrayPtr"),

                fields.unk164.Unwrap("LodPm", "unk164")

            );
        }
    }
}
