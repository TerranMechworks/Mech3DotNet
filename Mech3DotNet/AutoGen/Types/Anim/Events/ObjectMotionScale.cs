using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionScale
    {
        public Mech3DotNet.Types.Common.Vec3 initial;
        public Mech3DotNet.Types.Common.Vec3 delta;

        public ObjectMotionScale(Mech3DotNet.Types.Common.Vec3 initial, Mech3DotNet.Types.Common.Vec3 delta)
        {
            this.initial = initial;
            this.delta = delta;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ObjectMotionScale> Converter = new TypeConverter<ObjectMotionScale>(Deserialize, Serialize);

        public static void Serialize(ObjectMotionScale v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("initial");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.initial);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.delta);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Vec3> initial;
            public Field<Mech3DotNet.Types.Common.Vec3> delta;
        }

        public static ObjectMotionScale Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("ObjectMotionScale", fieldName);
                }
            }
            return new ObjectMotionScale(

                fields.initial.Unwrap("ObjectMotionScale", "initial"),

                fields.delta.Unwrap("ObjectMotionScale", "delta")

            );
        }

        #endregion
    }
}
