using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class TranslationOnly
    {
        public static readonly TypeConverter<TranslationOnly> Converter = new TypeConverter<TranslationOnly>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Vec3 translation;
        public Mech3DotNet.Types.Types.Matrix? matrix;

        public TranslationOnly(Mech3DotNet.Types.Types.Vec3 translation, Mech3DotNet.Types.Types.Matrix? matrix)
        {
            this.translation = translation;
            this.matrix = matrix;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Vec3> translation;
            public Field<Mech3DotNet.Types.Types.Matrix?> matrix;
        }

        public static void Serialize(TranslationOnly v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("translation");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.translation);
            s.SerializeFieldName("matrix");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.MatrixConverter.Converter))(v.matrix);
        }

        public static TranslationOnly Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                translation = new Field<Mech3DotNet.Types.Types.Vec3>(),
                matrix = new Field<Mech3DotNet.Types.Types.Matrix?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "translation":
                        fields.translation.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "matrix":
                        fields.matrix.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.MatrixConverter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("TranslationOnly", fieldName);
                }
            }
            return new TranslationOnly(

                fields.translation.Unwrap("TranslationOnly", "translation"),

                fields.matrix.Unwrap("TranslationOnly", "matrix")

            );
        }
    }
}
