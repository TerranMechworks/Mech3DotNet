using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionXyzRot
    {
        public static readonly TypeConverter<ObjectMotionXyzRot> Converter = new TypeConverter<ObjectMotionXyzRot>(Deserialize, Serialize);
        public Mech3DotNet.Types.Common.Vec3 initial;
        public Mech3DotNet.Types.Common.Vec3 delta;

        public ObjectMotionXyzRot(Mech3DotNet.Types.Common.Vec3 initial, Mech3DotNet.Types.Common.Vec3 delta)
        {
            this.initial = initial;
            this.delta = delta;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Vec3> initial;
            public Field<Mech3DotNet.Types.Common.Vec3> delta;
        }

        public static void Serialize(ObjectMotionXyzRot v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("initial");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.initial);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.delta);
        }

        public static ObjectMotionXyzRot Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                initial = new Field<Mech3DotNet.Types.Common.Vec3>(),
                delta = new Field<Mech3DotNet.Types.Common.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "initial":
                        fields.initial.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "delta":
                        fields.delta.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionXyzRot", fieldName);
                }
            }
            return new ObjectMotionXyzRot(

                fields.initial.Unwrap("ObjectMotionXyzRot", "initial"),

                fields.delta.Unwrap("ObjectMotionXyzRot", "delta")

            );
        }
    }
}
