using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Mw
{
    public sealed class Light
    {
        public static readonly TypeConverter<Light> Converter = new TypeConverter<Light>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Types.Vec3 direction;
        public float diffuse;
        public float ambient;
        public Mech3DotNet.Types.Types.Color color;
        public Mech3DotNet.Types.Types.Range range;
        public uint parentPtr;
        public uint dataPtr;

        public Light(string name, Mech3DotNet.Types.Types.Vec3 direction, float diffuse, float ambient, Mech3DotNet.Types.Types.Color color, Mech3DotNet.Types.Types.Range range, uint parentPtr, uint dataPtr)
        {
            this.name = name;
            this.direction = direction;
            this.diffuse = diffuse;
            this.ambient = ambient;
            this.color = color;
            this.range = range;
            this.parentPtr = parentPtr;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Types.Vec3> direction;
            public Field<float> diffuse;
            public Field<float> ambient;
            public Field<Mech3DotNet.Types.Types.Color> color;
            public Field<Mech3DotNet.Types.Types.Range> range;
            public Field<uint> parentPtr;
            public Field<uint> dataPtr;
        }

        public static void Serialize(Light v, Serializer s)
        {
            s.SerializeStruct(8);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("direction");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.direction);
            s.SerializeFieldName("diffuse");
            ((Action<float>)s.SerializeF32)(v.diffuse);
            s.SerializeFieldName("ambient");
            ((Action<float>)s.SerializeF32)(v.ambient);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Types.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter)(v.range);
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
                direction = new Field<Mech3DotNet.Types.Types.Vec3>(),
                diffuse = new Field<float>(),
                ambient = new Field<float>(),
                color = new Field<Mech3DotNet.Types.Types.Color>(),
                range = new Field<Mech3DotNet.Types.Types.Range>(),
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
                    case "direction":
                        fields.direction.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "diffuse":
                        fields.diffuse.Value = d.DeserializeF32();
                        break;
                    case "ambient":
                        fields.ambient.Value = d.DeserializeF32();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Types.ColorConverter.Converter)();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter)();
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

                fields.direction.Unwrap("Light", "direction"),

                fields.diffuse.Unwrap("Light", "diffuse"),

                fields.ambient.Unwrap("Light", "ambient"),

                fields.color.Unwrap("Light", "color"),

                fields.range.Unwrap("Light", "range"),

                fields.parentPtr.Unwrap("Light", "parentPtr"),

                fields.dataPtr.Unwrap("Light", "dataPtr")

            );
        }
    }
}
