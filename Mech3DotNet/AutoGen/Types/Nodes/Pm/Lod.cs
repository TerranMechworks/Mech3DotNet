using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Pm
{
    public sealed class Lod
    {
        public static readonly TypeConverter<Lod> Converter = new TypeConverter<Lod>(Deserialize, Serialize);
        public string name;
        public bool level;
        public Mech3DotNet.Types.Types.Range range;
        public float unk64;
        public float unk72;
        public uint zoneId;
        public uint parent;
        public System.Collections.Generic.List<uint> children;
        public Mech3DotNet.Types.Nodes.BoundingBox unk164;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public uint dataPtr;
        public uint nodeIndex;

        public Lod(string name, bool level, Mech3DotNet.Types.Types.Range range, float unk64, float unk72, uint zoneId, uint parent, System.Collections.Generic.List<uint> children, Mech3DotNet.Types.Nodes.BoundingBox unk164, uint parentArrayPtr, uint childrenArrayPtr, uint dataPtr, uint nodeIndex)
        {
            this.name = name;
            this.level = level;
            this.range = range;
            this.unk64 = unk64;
            this.unk72 = unk72;
            this.zoneId = zoneId;
            this.parent = parent;
            this.children = children;
            this.unk164 = unk164;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.dataPtr = dataPtr;
            this.nodeIndex = nodeIndex;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> level;
            public Field<Mech3DotNet.Types.Types.Range> range;
            public Field<float> unk64;
            public Field<float> unk72;
            public Field<uint> zoneId;
            public Field<uint> parent;
            public Field<System.Collections.Generic.List<uint>> children;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk164;
            public Field<uint> parentArrayPtr;
            public Field<uint> childrenArrayPtr;
            public Field<uint> dataPtr;
            public Field<uint> nodeIndex;
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
            s.SerializeFieldName("unk64");
            ((Action<float>)s.SerializeF32)(v.unk64);
            s.SerializeFieldName("unk72");
            ((Action<float>)s.SerializeF32)(v.unk72);
            s.SerializeFieldName("zone_id");
            ((Action<uint>)s.SerializeU32)(v.zoneId);
            s.SerializeFieldName("parent");
            ((Action<uint>)s.SerializeU32)(v.parent);
            s.SerializeFieldName("children");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.children);
            s.SerializeFieldName("unk164");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk164);
            s.SerializeFieldName("parent_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentArrayPtr);
            s.SerializeFieldName("children_array_ptr");
            ((Action<uint>)s.SerializeU32)(v.childrenArrayPtr);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
            s.SerializeFieldName("node_index");
            ((Action<uint>)s.SerializeU32)(v.nodeIndex);
        }

        public static Lod Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                level = new Field<bool>(),
                range = new Field<Mech3DotNet.Types.Types.Range>(),
                unk64 = new Field<float>(),
                unk72 = new Field<float>(),
                zoneId = new Field<uint>(),
                parent = new Field<uint>(),
                children = new Field<System.Collections.Generic.List<uint>>(),
                unk164 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                parentArrayPtr = new Field<uint>(),
                childrenArrayPtr = new Field<uint>(),
                dataPtr = new Field<uint>(),
                nodeIndex = new Field<uint>(),
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
                    case "unk64":
                        fields.unk64.Value = d.DeserializeF32();
                        break;
                    case "unk72":
                        fields.unk72.Value = d.DeserializeF32();
                        break;
                    case "zone_id":
                        fields.zoneId.Value = d.DeserializeU32();
                        break;
                    case "parent":
                        fields.parent.Value = d.DeserializeU32();
                        break;
                    case "children":
                        fields.children.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "unk164":
                        fields.unk164.Value = d.Deserialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)();
                        break;
                    case "parent_array_ptr":
                        fields.parentArrayPtr.Value = d.DeserializeU32();
                        break;
                    case "children_array_ptr":
                        fields.childrenArrayPtr.Value = d.DeserializeU32();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    case "node_index":
                        fields.nodeIndex.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Lod", fieldName);
                }
            }
            return new Lod(

                fields.name.Unwrap("Lod", "name"),

                fields.level.Unwrap("Lod", "level"),

                fields.range.Unwrap("Lod", "range"),

                fields.unk64.Unwrap("Lod", "unk64"),

                fields.unk72.Unwrap("Lod", "unk72"),

                fields.zoneId.Unwrap("Lod", "zoneId"),

                fields.parent.Unwrap("Lod", "parent"),

                fields.children.Unwrap("Lod", "children"),

                fields.unk164.Unwrap("Lod", "unk164"),

                fields.parentArrayPtr.Unwrap("Lod", "parentArrayPtr"),

                fields.childrenArrayPtr.Unwrap("Lod", "childrenArrayPtr"),

                fields.dataPtr.Unwrap("Lod", "dataPtr"),

                fields.nodeIndex.Unwrap("Lod", "nodeIndex")

            );
        }
    }
}
