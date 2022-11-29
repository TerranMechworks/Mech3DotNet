using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh
{
    public sealed class MeshLight
    {
        public static readonly TypeConverter<MeshLight> Converter = new TypeConverter<MeshLight>(Deserialize, Serialize);
        public uint unk00;
        public uint unk04;
        public float unk08;
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> extra;
        public uint unk24;
        public Mech3DotNet.Types.Types.Color color;
        public ushort flags;
        public uint ptr;
        public float unk48;
        public float unk52;
        public float unk56;
        public uint unk60;
        public float unk64;
        public float unk68;
        public float unk72;

        public MeshLight(uint unk00, uint unk04, float unk08, System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> extra, uint unk24, Mech3DotNet.Types.Types.Color color, ushort flags, uint ptr, float unk48, float unk52, float unk56, uint unk60, float unk64, float unk68, float unk72)
        {
            this.unk00 = unk00;
            this.unk04 = unk04;
            this.unk08 = unk08;
            this.extra = extra;
            this.unk24 = unk24;
            this.color = color;
            this.flags = flags;
            this.ptr = ptr;
            this.unk48 = unk48;
            this.unk52 = unk52;
            this.unk56 = unk56;
            this.unk60 = unk60;
            this.unk64 = unk64;
            this.unk68 = unk68;
            this.unk72 = unk72;
        }

        private struct Fields
        {
            public Field<uint> unk00;
            public Field<uint> unk04;
            public Field<float> unk08;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>> extra;
            public Field<uint> unk24;
            public Field<Mech3DotNet.Types.Types.Color> color;
            public Field<ushort> flags;
            public Field<uint> ptr;
            public Field<float> unk48;
            public Field<float> unk52;
            public Field<float> unk56;
            public Field<uint> unk60;
            public Field<float> unk64;
            public Field<float> unk68;
            public Field<float> unk72;
        }

        public static void Serialize(MeshLight v, Serializer s)
        {
            s.SerializeStruct("MeshLight", 15);
            s.SerializeFieldName("unk00");
            ((Action<uint>)s.SerializeU32)(v.unk00);
            s.SerializeFieldName("unk04");
            ((Action<uint>)s.SerializeU32)(v.unk04);
            s.SerializeFieldName("unk08");
            ((Action<float>)s.SerializeF32)(v.unk08);
            s.SerializeFieldName("extra");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.extra);
            s.SerializeFieldName("unk24");
            ((Action<uint>)s.SerializeU32)(v.unk24);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Types.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("flags");
            ((Action<ushort>)s.SerializeU16)(v.flags);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
            s.SerializeFieldName("unk48");
            ((Action<float>)s.SerializeF32)(v.unk48);
            s.SerializeFieldName("unk52");
            ((Action<float>)s.SerializeF32)(v.unk52);
            s.SerializeFieldName("unk56");
            ((Action<float>)s.SerializeF32)(v.unk56);
            s.SerializeFieldName("unk60");
            ((Action<uint>)s.SerializeU32)(v.unk60);
            s.SerializeFieldName("unk64");
            ((Action<float>)s.SerializeF32)(v.unk64);
            s.SerializeFieldName("unk68");
            ((Action<float>)s.SerializeF32)(v.unk68);
            s.SerializeFieldName("unk72");
            ((Action<float>)s.SerializeF32)(v.unk72);
        }

        public static MeshLight Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                unk00 = new Field<uint>(),
                unk04 = new Field<uint>(),
                unk08 = new Field<float>(),
                extra = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>>(),
                unk24 = new Field<uint>(),
                color = new Field<Mech3DotNet.Types.Types.Color>(),
                flags = new Field<ushort>(),
                ptr = new Field<uint>(),
                unk48 = new Field<float>(),
                unk52 = new Field<float>(),
                unk56 = new Field<float>(),
                unk60 = new Field<uint>(),
                unk64 = new Field<float>(),
                unk68 = new Field<float>(),
                unk72 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("MeshLight"))
            {
                switch (fieldName)
                {
                    case "unk00":
                        fields.unk00.Value = d.DeserializeU32();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeU32();
                        break;
                    case "unk08":
                        fields.unk08.Value = d.DeserializeF32();
                        break;
                    case "extra":
                        fields.extra.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "unk24":
                        fields.unk24.Value = d.DeserializeU32();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Types.ColorConverter.Converter)();
                        break;
                    case "flags":
                        fields.flags.Value = d.DeserializeU16();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    case "unk48":
                        fields.unk48.Value = d.DeserializeF32();
                        break;
                    case "unk52":
                        fields.unk52.Value = d.DeserializeF32();
                        break;
                    case "unk56":
                        fields.unk56.Value = d.DeserializeF32();
                        break;
                    case "unk60":
                        fields.unk60.Value = d.DeserializeU32();
                        break;
                    case "unk64":
                        fields.unk64.Value = d.DeserializeF32();
                        break;
                    case "unk68":
                        fields.unk68.Value = d.DeserializeF32();
                        break;
                    case "unk72":
                        fields.unk72.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("MeshLight", fieldName);
                }
            }
            return new MeshLight(

                fields.unk00.Unwrap("MeshLight", "unk00"),

                fields.unk04.Unwrap("MeshLight", "unk04"),

                fields.unk08.Unwrap("MeshLight", "unk08"),

                fields.extra.Unwrap("MeshLight", "extra"),

                fields.unk24.Unwrap("MeshLight", "unk24"),

                fields.color.Unwrap("MeshLight", "color"),

                fields.flags.Unwrap("MeshLight", "flags"),

                fields.ptr.Unwrap("MeshLight", "ptr"),

                fields.unk48.Unwrap("MeshLight", "unk48"),

                fields.unk52.Unwrap("MeshLight", "unk52"),

                fields.unk56.Unwrap("MeshLight", "unk56"),

                fields.unk60.Unwrap("MeshLight", "unk60"),

                fields.unk64.Unwrap("MeshLight", "unk64"),

                fields.unk68.Unwrap("MeshLight", "unk68"),

                fields.unk72.Unwrap("MeshLight", "unk72")

            );
        }
    }
}
