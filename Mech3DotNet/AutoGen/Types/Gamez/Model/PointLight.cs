using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    public sealed class PointLight
    {
        public static readonly TypeConverter<PointLight> Converter = new TypeConverter<PointLight>(Deserialize, Serialize);
        public int unk00;
        public int unk04;
        public float unk08;
        public System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> vertices;
        public uint unk24;
        public Mech3DotNet.Types.Common.Color color;
        public ushort flags;
        public uint verticesPtr;
        public float unk48;
        public float unk52;
        public float unk56;
        public int unk60;
        public float unk64;
        public float unk68;
        public float unk72;

        public PointLight(int unk00, int unk04, float unk08, System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> vertices, uint unk24, Mech3DotNet.Types.Common.Color color, ushort flags, uint verticesPtr, float unk48, float unk52, float unk56, int unk60, float unk64, float unk68, float unk72)
        {
            this.unk00 = unk00;
            this.unk04 = unk04;
            this.unk08 = unk08;
            this.vertices = vertices;
            this.unk24 = unk24;
            this.color = color;
            this.flags = flags;
            this.verticesPtr = verticesPtr;
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
            public Field<int> unk00;
            public Field<int> unk04;
            public Field<float> unk08;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>> vertices;
            public Field<uint> unk24;
            public Field<Mech3DotNet.Types.Common.Color> color;
            public Field<ushort> flags;
            public Field<uint> verticesPtr;
            public Field<float> unk48;
            public Field<float> unk52;
            public Field<float> unk56;
            public Field<int> unk60;
            public Field<float> unk64;
            public Field<float> unk68;
            public Field<float> unk72;
        }

        public static void Serialize(PointLight v, Serializer s)
        {
            s.SerializeStruct(15);
            s.SerializeFieldName("unk00");
            ((Action<int>)s.SerializeI32)(v.unk00);
            s.SerializeFieldName("unk04");
            ((Action<int>)s.SerializeI32)(v.unk04);
            s.SerializeFieldName("unk08");
            ((Action<float>)s.SerializeF32)(v.unk08);
            s.SerializeFieldName("vertices");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.vertices);
            s.SerializeFieldName("unk24");
            ((Action<uint>)s.SerializeU32)(v.unk24);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("flags");
            ((Action<ushort>)s.SerializeU16)(v.flags);
            s.SerializeFieldName("vertices_ptr");
            ((Action<uint>)s.SerializeU32)(v.verticesPtr);
            s.SerializeFieldName("unk48");
            ((Action<float>)s.SerializeF32)(v.unk48);
            s.SerializeFieldName("unk52");
            ((Action<float>)s.SerializeF32)(v.unk52);
            s.SerializeFieldName("unk56");
            ((Action<float>)s.SerializeF32)(v.unk56);
            s.SerializeFieldName("unk60");
            ((Action<int>)s.SerializeI32)(v.unk60);
            s.SerializeFieldName("unk64");
            ((Action<float>)s.SerializeF32)(v.unk64);
            s.SerializeFieldName("unk68");
            ((Action<float>)s.SerializeF32)(v.unk68);
            s.SerializeFieldName("unk72");
            ((Action<float>)s.SerializeF32)(v.unk72);
        }

        public static PointLight Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                unk00 = new Field<int>(),
                unk04 = new Field<int>(),
                unk08 = new Field<float>(),
                vertices = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>>(),
                unk24 = new Field<uint>(),
                color = new Field<Mech3DotNet.Types.Common.Color>(),
                flags = new Field<ushort>(),
                verticesPtr = new Field<uint>(),
                unk48 = new Field<float>(),
                unk52 = new Field<float>(),
                unk56 = new Field<float>(),
                unk60 = new Field<int>(),
                unk64 = new Field<float>(),
                unk68 = new Field<float>(),
                unk72 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "unk00":
                        fields.unk00.Value = d.DeserializeI32();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeI32();
                        break;
                    case "unk08":
                        fields.unk08.Value = d.DeserializeF32();
                        break;
                    case "vertices":
                        fields.vertices.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "unk24":
                        fields.unk24.Value = d.DeserializeU32();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "flags":
                        fields.flags.Value = d.DeserializeU16();
                        break;
                    case "vertices_ptr":
                        fields.verticesPtr.Value = d.DeserializeU32();
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
                        fields.unk60.Value = d.DeserializeI32();
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
                        throw new UnknownFieldException("PointLight", fieldName);
                }
            }
            return new PointLight(

                fields.unk00.Unwrap("PointLight", "unk00"),

                fields.unk04.Unwrap("PointLight", "unk04"),

                fields.unk08.Unwrap("PointLight", "unk08"),

                fields.vertices.Unwrap("PointLight", "vertices"),

                fields.unk24.Unwrap("PointLight", "unk24"),

                fields.color.Unwrap("PointLight", "color"),

                fields.flags.Unwrap("PointLight", "flags"),

                fields.verticesPtr.Unwrap("PointLight", "verticesPtr"),

                fields.unk48.Unwrap("PointLight", "unk48"),

                fields.unk52.Unwrap("PointLight", "unk52"),

                fields.unk56.Unwrap("PointLight", "unk56"),

                fields.unk60.Unwrap("PointLight", "unk60"),

                fields.unk64.Unwrap("PointLight", "unk64"),

                fields.unk68.Unwrap("PointLight", "unk68"),

                fields.unk72.Unwrap("PointLight", "unk72")

            );
        }
    }
}
