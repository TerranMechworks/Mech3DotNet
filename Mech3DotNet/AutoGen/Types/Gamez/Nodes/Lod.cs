using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Lod
    {
        public static readonly TypeConverter<Lod> Converter = new TypeConverter<Lod>(Deserialize, Serialize);
        public int field00;
        public Mech3DotNet.Types.Common.Range range;
        public float field16;
        public float field20;
        public float field24;
        public float field28;
        public float field32;
        public float field36;
        public float field40;
        public float field44;
        public int field48;
        public float field52;
        public float field56;
        public float field60;
        public float field64;
        public int field68;
        public float field72;
        public float field76;

        public Lod(int field00, Mech3DotNet.Types.Common.Range range, float field16, float field20, float field24, float field28, float field32, float field36, float field40, float field44, int field48, float field52, float field56, float field60, float field64, int field68, float field72, float field76)
        {
            this.field00 = field00;
            this.range = range;
            this.field16 = field16;
            this.field20 = field20;
            this.field24 = field24;
            this.field28 = field28;
            this.field32 = field32;
            this.field36 = field36;
            this.field40 = field40;
            this.field44 = field44;
            this.field48 = field48;
            this.field52 = field52;
            this.field56 = field56;
            this.field60 = field60;
            this.field64 = field64;
            this.field68 = field68;
            this.field72 = field72;
            this.field76 = field76;
        }

        private struct Fields
        {
            public Field<int> field00;
            public Field<Mech3DotNet.Types.Common.Range> range;
            public Field<float> field16;
            public Field<float> field20;
            public Field<float> field24;
            public Field<float> field28;
            public Field<float> field32;
            public Field<float> field36;
            public Field<float> field40;
            public Field<float> field44;
            public Field<int> field48;
            public Field<float> field52;
            public Field<float> field56;
            public Field<float> field60;
            public Field<float> field64;
            public Field<int> field68;
            public Field<float> field72;
            public Field<float> field76;
        }

        public static void Serialize(Lod v, Serializer s)
        {
            s.SerializeStruct(18);
            s.SerializeFieldName("field00");
            ((Action<int>)s.SerializeI32)(v.field00);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.range);
            s.SerializeFieldName("field16");
            ((Action<float>)s.SerializeF32)(v.field16);
            s.SerializeFieldName("field20");
            ((Action<float>)s.SerializeF32)(v.field20);
            s.SerializeFieldName("field24");
            ((Action<float>)s.SerializeF32)(v.field24);
            s.SerializeFieldName("field28");
            ((Action<float>)s.SerializeF32)(v.field28);
            s.SerializeFieldName("field32");
            ((Action<float>)s.SerializeF32)(v.field32);
            s.SerializeFieldName("field36");
            ((Action<float>)s.SerializeF32)(v.field36);
            s.SerializeFieldName("field40");
            ((Action<float>)s.SerializeF32)(v.field40);
            s.SerializeFieldName("field44");
            ((Action<float>)s.SerializeF32)(v.field44);
            s.SerializeFieldName("field48");
            ((Action<int>)s.SerializeI32)(v.field48);
            s.SerializeFieldName("field52");
            ((Action<float>)s.SerializeF32)(v.field52);
            s.SerializeFieldName("field56");
            ((Action<float>)s.SerializeF32)(v.field56);
            s.SerializeFieldName("field60");
            ((Action<float>)s.SerializeF32)(v.field60);
            s.SerializeFieldName("field64");
            ((Action<float>)s.SerializeF32)(v.field64);
            s.SerializeFieldName("field68");
            ((Action<int>)s.SerializeI32)(v.field68);
            s.SerializeFieldName("field72");
            ((Action<float>)s.SerializeF32)(v.field72);
            s.SerializeFieldName("field76");
            ((Action<float>)s.SerializeF32)(v.field76);
        }

        public static Lod Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                field00 = new Field<int>(),
                range = new Field<Mech3DotNet.Types.Common.Range>(),
                field16 = new Field<float>(),
                field20 = new Field<float>(),
                field24 = new Field<float>(),
                field28 = new Field<float>(),
                field32 = new Field<float>(),
                field36 = new Field<float>(),
                field40 = new Field<float>(),
                field44 = new Field<float>(),
                field48 = new Field<int>(),
                field52 = new Field<float>(),
                field56 = new Field<float>(),
                field60 = new Field<float>(),
                field64 = new Field<float>(),
                field68 = new Field<int>(),
                field72 = new Field<float>(),
                field76 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "field00":
                        fields.field00.Value = d.DeserializeI32();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "field16":
                        fields.field16.Value = d.DeserializeF32();
                        break;
                    case "field20":
                        fields.field20.Value = d.DeserializeF32();
                        break;
                    case "field24":
                        fields.field24.Value = d.DeserializeF32();
                        break;
                    case "field28":
                        fields.field28.Value = d.DeserializeF32();
                        break;
                    case "field32":
                        fields.field32.Value = d.DeserializeF32();
                        break;
                    case "field36":
                        fields.field36.Value = d.DeserializeF32();
                        break;
                    case "field40":
                        fields.field40.Value = d.DeserializeF32();
                        break;
                    case "field44":
                        fields.field44.Value = d.DeserializeF32();
                        break;
                    case "field48":
                        fields.field48.Value = d.DeserializeI32();
                        break;
                    case "field52":
                        fields.field52.Value = d.DeserializeF32();
                        break;
                    case "field56":
                        fields.field56.Value = d.DeserializeF32();
                        break;
                    case "field60":
                        fields.field60.Value = d.DeserializeF32();
                        break;
                    case "field64":
                        fields.field64.Value = d.DeserializeF32();
                        break;
                    case "field68":
                        fields.field68.Value = d.DeserializeI32();
                        break;
                    case "field72":
                        fields.field72.Value = d.DeserializeF32();
                        break;
                    case "field76":
                        fields.field76.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Lod", fieldName);
                }
            }
            return new Lod(

                fields.field00.Unwrap("Lod", "field00"),

                fields.range.Unwrap("Lod", "range"),

                fields.field16.Unwrap("Lod", "field16"),

                fields.field20.Unwrap("Lod", "field20"),

                fields.field24.Unwrap("Lod", "field24"),

                fields.field28.Unwrap("Lod", "field28"),

                fields.field32.Unwrap("Lod", "field32"),

                fields.field36.Unwrap("Lod", "field36"),

                fields.field40.Unwrap("Lod", "field40"),

                fields.field44.Unwrap("Lod", "field44"),

                fields.field48.Unwrap("Lod", "field48"),

                fields.field52.Unwrap("Lod", "field52"),

                fields.field56.Unwrap("Lod", "field56"),

                fields.field60.Unwrap("Lod", "field60"),

                fields.field64.Unwrap("Lod", "field64"),

                fields.field68.Unwrap("Lod", "field68"),

                fields.field72.Unwrap("Lod", "field72"),

                fields.field76.Unwrap("Lod", "field76")

            );
        }
    }
}
