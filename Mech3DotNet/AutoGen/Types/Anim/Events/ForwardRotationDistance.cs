using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ForwardRotationDistance
    {
        public float initial;

        public ForwardRotationDistance(float initial)
        {
            this.initial = initial;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ForwardRotationDistance> Converter = new TypeConverter<ForwardRotationDistance>(Deserialize, Serialize);

        public static void Serialize(ForwardRotationDistance v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("initial");
            ((Action<float>)s.SerializeF32)(v.initial);
        }

        private struct Fields
        {
            public Field<float> initial;
        }

        public static ForwardRotationDistance Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                initial = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "initial":
                        fields.initial.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("ForwardRotationDistance", fieldName);
                }
            }
            return new ForwardRotationDistance(

                fields.initial.Unwrap("ForwardRotationDistance", "initial")

            );
        }

        #endregion
    }
}
