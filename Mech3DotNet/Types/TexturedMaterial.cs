using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public sealed class TexturedMaterial
    {
        public static readonly TypeConverter<TexturedMaterial> Converter = new TypeConverter<TexturedMaterial>(Deserialize, Serialize);
        public string texture;
        public uint pointer = 0;
        public Mech3DotNet.Types.Gamez.Materials.CycleData? cycle = null;
        public float specular;
        public bool flag;

        public TexturedMaterial(string texture, uint pointer, Mech3DotNet.Types.Gamez.Materials.CycleData? cycle, float specular, bool flag)
        {
            this.texture = texture;
            this.pointer = pointer;
            this.cycle = cycle;
            this.specular = specular;
            this.flag = flag;
        }

        private struct Fields
        {
            public Field<string> texture;
            public Field<uint> pointer;
            public Field<Mech3DotNet.Types.Gamez.Materials.CycleData?> cycle;
            public Field<float> specular;
            public Field<bool> flag;
        }

        public static void Serialize(Mech3DotNet.Types.Gamez.Materials.TexturedMaterial v, Serializer s)
        {
            s.SerializeStruct("TexturedMaterial", 5);
            s.SerializeFieldName("texture");
            ((Action<string>)s.SerializeString)(v.texture);
            s.SerializeFieldName("pointer");
            ((Action<uint>)s.SerializeU32)(v.pointer);
            s.SerializeFieldName("cycle");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Gamez.Materials.CycleData.Converter))(v.cycle);
            s.SerializeFieldName("specular");
            ((Action<float>)s.SerializeF32)(v.specular);
            s.SerializeFieldName("flag");
            ((Action<bool>)s.SerializeBool)(v.flag);
        }

        public static Mech3DotNet.Types.Gamez.Materials.TexturedMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                texture = new Field<string>(),
                pointer = new Field<uint>(0),
                cycle = new Field<Mech3DotNet.Types.Gamez.Materials.CycleData?>(null),
                specular = new Field<float>(),
                flag = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct("TexturedMaterial"))
            {
                switch (fieldName)
                {
                    case "texture":
                        fields.texture.Value = d.DeserializeString();
                        break;
                    case "pointer":
                        fields.pointer.Value = d.DeserializeU32();
                        break;
                    case "cycle":
                        fields.cycle.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Gamez.Materials.CycleData.Converter))();
                        break;
                    case "specular":
                        fields.specular.Value = d.DeserializeF32();
                        break;
                    case "flag":
                        fields.flag.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("TexturedMaterial", fieldName);
                }
            }
            return new TexturedMaterial(

                fields.texture.Unwrap("TexturedMaterial", "texture"),

                fields.pointer.Unwrap("TexturedMaterial", "pointer"),

                fields.cycle.Unwrap("TexturedMaterial", "cycle"),

                fields.specular.Unwrap("TexturedMaterial", "specular"),

                fields.flag.Unwrap("TexturedMaterial", "flag")

            );
        }
    }
}
