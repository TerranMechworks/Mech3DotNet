using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Mw
{
    public sealed class Empty
    {
        public static readonly TypeConverter<Empty> Converter = new TypeConverter<Empty>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Nodes.NodeFlags flags;
        public uint unk044;
        public uint zoneId;
        public Mech3DotNet.Types.Nodes.BoundingBox unk116;
        public Mech3DotNet.Types.Nodes.BoundingBox unk140;
        public Mech3DotNet.Types.Nodes.BoundingBox unk164;
        public uint parent;

        public Empty(string name, Mech3DotNet.Types.Nodes.NodeFlags flags, uint unk044, uint zoneId, Mech3DotNet.Types.Nodes.BoundingBox unk116, Mech3DotNet.Types.Nodes.BoundingBox unk140, Mech3DotNet.Types.Nodes.BoundingBox unk164, uint parent)
        {
            this.name = name;
            this.flags = flags;
            this.unk044 = unk044;
            this.zoneId = zoneId;
            this.unk116 = unk116;
            this.unk140 = unk140;
            this.unk164 = unk164;
            this.parent = parent;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Nodes.NodeFlags> flags;
            public Field<uint> unk044;
            public Field<uint> zoneId;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk116;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk140;
            public Field<Mech3DotNet.Types.Nodes.BoundingBox> unk164;
            public Field<uint> parent;
        }

        public static void Serialize(Empty v, Serializer s)
        {
            s.SerializeStruct(8);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)(v.flags);
            s.SerializeFieldName("unk044");
            ((Action<uint>)s.SerializeU32)(v.unk044);
            s.SerializeFieldName("zone_id");
            ((Action<uint>)s.SerializeU32)(v.zoneId);
            s.SerializeFieldName("unk116");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk116);
            s.SerializeFieldName("unk140");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk140);
            s.SerializeFieldName("unk164");
            s.Serialize(Mech3DotNet.Types.Nodes.BoundingBox.Converter)(v.unk164);
            s.SerializeFieldName("parent");
            ((Action<uint>)s.SerializeU32)(v.parent);
        }

        public static Empty Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                flags = new Field<Mech3DotNet.Types.Nodes.NodeFlags>(),
                unk044 = new Field<uint>(),
                zoneId = new Field<uint>(),
                unk116 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk140 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                unk164 = new Field<Mech3DotNet.Types.Nodes.BoundingBox>(),
                parent = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Nodes.NodeFlags.Converter)();
                        break;
                    case "unk044":
                        fields.unk044.Value = d.DeserializeU32();
                        break;
                    case "zone_id":
                        fields.zoneId.Value = d.DeserializeU32();
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
                    case "parent":
                        fields.parent.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Empty", fieldName);
                }
            }
            return new Empty(

                fields.name.Unwrap("Empty", "name"),

                fields.flags.Unwrap("Empty", "flags"),

                fields.unk044.Unwrap("Empty", "unk044"),

                fields.zoneId.Unwrap("Empty", "zoneId"),

                fields.unk116.Unwrap("Empty", "unk116"),

                fields.unk140.Unwrap("Empty", "unk140"),

                fields.unk164.Unwrap("Empty", "unk164"),

                fields.parent.Unwrap("Empty", "parent")

            );
        }
    }
}
