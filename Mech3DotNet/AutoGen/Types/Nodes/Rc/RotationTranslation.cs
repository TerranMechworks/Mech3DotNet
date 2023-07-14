using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class RotationTranslation
    {
        public static readonly TypeConverter<RotationTranslation> Converter = new TypeConverter<RotationTranslation>(Deserialize, Serialize);
        public Mech3DotNet.Types.Vec3 rotation;
        public Mech3DotNet.Types.Vec3 translation;

        public RotationTranslation(Mech3DotNet.Types.Vec3 rotation, Mech3DotNet.Types.Vec3 translation)
        {
            this.rotation = rotation;
            this.translation = translation;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Vec3> rotation;
            public Field<Mech3DotNet.Types.Vec3> translation;
        }

        public static void Serialize(RotationTranslation v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("rotation");
            s.Serialize(Mech3DotNet.Types.Vec3Converter.Converter)(v.rotation);
            s.SerializeFieldName("translation");
            s.Serialize(Mech3DotNet.Types.Vec3Converter.Converter)(v.translation);
        }

        public static RotationTranslation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                rotation = new Field<Mech3DotNet.Types.Vec3>(),
                translation = new Field<Mech3DotNet.Types.Vec3>(),
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
                    default:
                        throw new UnknownFieldException("RotationTranslation", fieldName);
                }
            }
            return new RotationTranslation(

                fields.rotation.Unwrap("RotationTranslation", "rotation"),

                fields.translation.Unwrap("RotationTranslation", "translation")

            );
        }
    }
}
