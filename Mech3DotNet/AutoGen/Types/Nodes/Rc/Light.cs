using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class Light
    {
        public static readonly TypeConverter<Light> Converter = new TypeConverter<Light>(Deserialize, Serialize);
        public string name;
        public float unk008;
        public float unk012;
        public Mech3DotNet.Types.Color color;
        public Mech3DotNet.Types.Range range;
        public uint parentPtr;
        public uint dataPtr;

        public Light(string name, float unk008, float unk012, Mech3DotNet.Types.Color color, Mech3DotNet.Types.Range range, uint parentPtr, uint dataPtr)
        {
            this.name = name;
            this.unk008 = unk008;
            this.unk012 = unk012;
            this.color = color;
            this.range = range;
            this.parentPtr = parentPtr;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<float> unk008;
            public Field<float> unk012;
            public Field<Mech3DotNet.Types.Color> color;
            public Field<Mech3DotNet.Types.Range> range;
            public Field<uint> parentPtr;
            public Field<uint> dataPtr;
        }

        public static void Serialize(Light v, Serializer s)
        {
            s.SerializeStruct(7);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("unk008");
            ((Action<float>)s.SerializeF32)(v.unk008);
            s.SerializeFieldName("unk012");
            ((Action<float>)s.SerializeF32)(v.unk012);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.RangeConverter.Converter)(v.range);
            s.SerializeFieldName("parent_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentPtr);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
        }

        public static Light Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                unk008 = new Field<float>(),
                unk012 = new Field<float>(),
                color = new Field<Mech3DotNet.Types.Color>(),
                range = new Field<Mech3DotNet.Types.Range>(),
                parentPtr = new Field<uint>(),
                dataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "unk008":
                        fields.unk008.Value = d.DeserializeF32();
                        break;
                    case "unk012":
                        fields.unk012.Value = d.DeserializeF32();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.ColorConverter.Converter)();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.RangeConverter.Converter)();
                        break;
                    case "parent_ptr":
                        fields.parentPtr.Value = d.DeserializeU32();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Light", fieldName);
                }
            }
            return new Light(

                fields.name.Unwrap("Light", "name"),

                fields.unk008.Unwrap("Light", "unk008"),

                fields.unk012.Unwrap("Light", "unk012"),

                fields.color.Unwrap("Light", "color"),

                fields.range.Unwrap("Light", "range"),

                fields.parentPtr.Unwrap("Light", "parentPtr"),

                fields.dataPtr.Unwrap("Light", "dataPtr")

            );
        }
    }
}
