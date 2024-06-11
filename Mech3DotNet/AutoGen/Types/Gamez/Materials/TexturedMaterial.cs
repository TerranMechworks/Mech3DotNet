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
        public Mech3DotNet.Types.Gamez.Materials.Soil soil = Mech3DotNet.Types.Gamez.Materials.Soil.Default;
        public bool flag;

        public TexturedMaterial(string texture, uint pointer, Mech3DotNet.Types.Gamez.Materials.CycleData? cycle, Mech3DotNet.Types.Gamez.Materials.Soil soil, bool flag)
        {
            this.texture = texture;
            this.pointer = pointer;
            this.cycle = cycle;
            this.soil = soil;
            this.flag = flag;
        }

        private struct Fields
        {
            public Field<string> texture;
            public Field<uint> pointer;
            public Field<Mech3DotNet.Types.Gamez.Materials.CycleData?> cycle;
            public Field<Mech3DotNet.Types.Gamez.Materials.Soil> soil;
            public Field<bool> flag;
        }

        public static void Serialize(TexturedMaterial v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("texture");
            ((Action<string>)s.SerializeString)(v.texture);
            s.SerializeFieldName("pointer");
            ((Action<uint>)s.SerializeU32)(v.pointer);
            s.SerializeFieldName("cycle");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Gamez.Materials.CycleData.Converter))(v.cycle);
            s.SerializeFieldName("soil");
            s.Serialize(Mech3DotNet.Types.Gamez.Materials.SoilConverter.Converter)(v.soil);
            s.SerializeFieldName("flag");
            ((Action<bool>)s.SerializeBool)(v.flag);
        }

        public static TexturedMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                texture = new Field<string>(),
                pointer = new Field<uint>(0),
                cycle = new Field<Mech3DotNet.Types.Gamez.Materials.CycleData?>(null),
                soil = new Field<Mech3DotNet.Types.Gamez.Materials.Soil>(Mech3DotNet.Types.Gamez.Materials.Soil.Default),
                flag = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
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
                    case "soil":
                        fields.soil.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Materials.SoilConverter.Converter)();
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

                fields.soil.Unwrap("TexturedMaterial", "soil"),

                fields.flag.Unwrap("TexturedMaterial", "flag")

            );
        }
    }
}
