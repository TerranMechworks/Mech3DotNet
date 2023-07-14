using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class Transformation
    {
        public static readonly TypeConverter<Transformation> Converter = new TypeConverter<Transformation>(Deserialize, Serialize);
        public Mech3DotNet.Types.Vec3 rotation;
        public Mech3DotNet.Types.Vec3 translation;
        public Mech3DotNet.Types.Matrix? matrix;

        public Transformation(Mech3DotNet.Types.Vec3 rotation, Mech3DotNet.Types.Vec3 translation, Mech3DotNet.Types.Matrix? matrix)
        {
            this.rotation = rotation;
            this.translation = translation;
            this.matrix = matrix;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Vec3> rotation;
            public Field<Mech3DotNet.Types.Vec3> translation;
            public Field<Mech3DotNet.Types.Matrix?> matrix;
        }

        public static void Serialize(Transformation v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("rotation");
            s.Serialize(Mech3DotNet.Types.Vec3Converter.Converter)(v.rotation);
            s.SerializeFieldName("translation");
            s.Serialize(Mech3DotNet.Types.Vec3Converter.Converter)(v.translation);
            s.SerializeFieldName("matrix");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.MatrixConverter.Converter))(v.matrix);
        }

        public static Transformation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                rotation = new Field<Mech3DotNet.Types.Vec3>(),
                translation = new Field<Mech3DotNet.Types.Vec3>(),
                matrix = new Field<Mech3DotNet.Types.Matrix?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "rotation":
                        fields.rotation.Value = d.Deserialize(Mech3DotNet.Types.Vec3Converter.Converter)();
                        break;
                    case "translation":
                        fields.translation.Value = d.Deserialize(Mech3DotNet.Types.Vec3Converter.Converter)();
                        break;
                    case "matrix":
                        fields.matrix.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.MatrixConverter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("Transformation", fieldName);
                }
            }
            return new Transformation(

                fields.rotation.Unwrap("Transformation", "rotation"),

                fields.translation.Unwrap("Transformation", "translation"),

                fields.matrix.Unwrap("Transformation", "matrix")

            );
        }
    }
}
