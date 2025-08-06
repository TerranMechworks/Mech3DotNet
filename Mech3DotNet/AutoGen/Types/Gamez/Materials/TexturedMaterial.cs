using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public sealed class TexturedMaterial
    {
        public short textureIndex;
        public Mech3DotNet.Types.Gamez.Materials.Soil soil = Mech3DotNet.Types.Gamez.Materials.Soil.Default;
        public Mech3DotNet.Types.Gamez.Materials.CycleData? cycle = null;
        public bool flag;

        public TexturedMaterial(short textureIndex, Mech3DotNet.Types.Gamez.Materials.Soil soil, Mech3DotNet.Types.Gamez.Materials.CycleData? cycle, bool flag)
        {
            this.textureIndex = textureIndex;
            this.soil = soil;
            this.cycle = cycle;
            this.flag = flag;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<TexturedMaterial> Converter = new TypeConverter<TexturedMaterial>(Deserialize, Serialize);

        public static void Serialize(TexturedMaterial v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("texture_index");
            ((Action<short>)s.SerializeI16)(v.textureIndex);
            s.SerializeFieldName("soil");
            s.Serialize(Mech3DotNet.Types.Gamez.Materials.SoilConverter.Converter)(v.soil);
            s.SerializeFieldName("cycle");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Gamez.Materials.CycleData.Converter))(v.cycle);
            s.SerializeFieldName("flag");
            ((Action<bool>)s.SerializeBool)(v.flag);
        }

        private struct Fields
        {
            public Field<short> textureIndex;
            public Field<Mech3DotNet.Types.Gamez.Materials.Soil> soil;
            public Field<Mech3DotNet.Types.Gamez.Materials.CycleData?> cycle;
            public Field<bool> flag;
        }

        public static TexturedMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textureIndex = new Field<short>(),
                soil = new Field<Mech3DotNet.Types.Gamez.Materials.Soil>(Mech3DotNet.Types.Gamez.Materials.Soil.Default),
                cycle = new Field<Mech3DotNet.Types.Gamez.Materials.CycleData?>(null),
                flag = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "texture_index":
                        fields.textureIndex.Value = d.DeserializeI16();
                        break;
                    case "soil":
                        fields.soil.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Materials.SoilConverter.Converter)();
                        break;
                    case "cycle":
                        fields.cycle.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Gamez.Materials.CycleData.Converter))();
                        break;
                    case "flag":
                        fields.flag.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("TexturedMaterial", fieldName);
                }
            }
            return new TexturedMaterial(

                fields.textureIndex.Unwrap("TexturedMaterial", "textureIndex"),

                fields.soil.Unwrap("TexturedMaterial", "soil"),

                fields.cycle.Unwrap("TexturedMaterial", "cycle"),

                fields.flag.Unwrap("TexturedMaterial", "flag")

            );
        }

        #endregion
    }
}
