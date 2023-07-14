using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class Lod
    {
        public static readonly TypeConverter<Lod> Converter = new TypeConverter<Lod>(Deserialize, Serialize);
        public string name;
        public bool level;
        public Mech3DotNet.Types.Types.Range range;
        public float unk60;
        public uint? unk76;
        public Mech3DotNet.Types.Nodes.NodeFlags flags;
        public uint zoneId;
        public uint? parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public Mech3DotNet.Types.Nodes.BoundingBox unk116;

        public Lod(string name, bool level, Mech3DotNet.Types.Types.Range range, float unk60, uint? unk76, Mech3DotNet.Types.Nodes.NodeFlags flags, uint zoneId, uint? parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Mech3DotNet.Types.Nodes.BoundingBox unk116)
        {
            this.name = name;
            this.level = level;
            this.range = range;
            this.unk60 = unk60;
            this.unk76 = unk76;
            this.flags = flags;
            this.zoneId = zoneId;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk116 = unk116;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> level;
            public Field<Mech3DotNet.Types.Types.Range> range;
            public Field<float> unk60;
            public Field<uint?> unk76;
            public Field<Mech3DotNet.Types.Nodes.NodeFlags> flags;
            public Field<uint> zoneId;
            public Field<uint?> parent;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<uint> dataPtr;
            public Field<uint> parentArrayPtr;
            public Field<uint> childrenArrayPtr;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk116;
        }

        public static void Serialize(Lod v, Serializer s)
        {
            s.SerializeStruct(13);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("level");
            ((Action<bool>)s.SerializeBool)(v.level);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter)(v.range);
            s.SerializeFieldName("unk60");
            ((Action<float>)s.SerializeF32)(v.unk60);
            s.SerializeFieldName("unk76");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.unk76);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)(v.flags);
            s.SerializeFieldName("zone_id");
            ((Action<uint>)s.SerializeU32)(v.zoneId);
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
        }

        public static Lod Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                level = new Field<bool>(),
                range = new Field<Mech3DotNet.Types.Types.Range>(),
                unk60 = new Field<float>(),
                unk76 = new Field<uint?>(),
                flags = new Field<Mech3DotNet.Types.Nodes.NodeFlags>(),
                zoneId = new Field<uint>(),
                parent = new Field<uint?>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                dataPtr = new Field<uint>(),
                parentArrayPtr = new Field<uint>(),
                childrenArrayPtr = new Field<uint>(),
                unk116 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
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
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter)();
                        break;
                    case "unk60":
                        fields.unk60.Value = d.DeserializeF32();
                        break;
                    case "unk76":
                        fields.unk76.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)();
                        break;
                    case "zone_id":
                        fields.zoneId.Value = d.DeserializeU32();
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
                    default:
                        throw new UnknownFieldException("Lod", fieldName);
                }
            }
            return new Lod(

                fields.name.Unwrap("Lod", "name"),

                fields.level.Unwrap("Lod", "level"),

                fields.range.Unwrap("Lod", "range"),

                fields.unk60.Unwrap("Lod", "unk60"),

                fields.unk76.Unwrap("Lod", "unk76"),

                fields.flags.Unwrap("Lod", "flags"),

                fields.zoneId.Unwrap("Lod", "zoneId"),

                fields.parent.Unwrap("Lod", "parent"),

                fields.children.Unwrap("Lod", "children"),

                fields.dataPtr.Unwrap("Lod", "dataPtr"),

                fields.parentArrayPtr.Unwrap("Lod", "parentArrayPtr"),

                fields.childrenArrayPtr.Unwrap("Lod", "childrenArrayPtr"),

                fields.unk116.Unwrap("Lod", "unk116")

            );
        }
    }
}
