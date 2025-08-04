using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionTranslation
    {
        public static readonly TypeConverter<ObjectMotionTranslation> Converter = new TypeConverter<ObjectMotionTranslation>(Deserialize, Serialize);
        public Mech3DotNet.Types.Common.Vec3 initial;
        public Mech3DotNet.Types.Common.Vec3 delta;
        public Mech3DotNet.Types.Common.Vec3 rndXz;

        public ObjectMotionTranslation(Mech3DotNet.Types.Common.Vec3 initial, Mech3DotNet.Types.Common.Vec3 delta, Mech3DotNet.Types.Common.Vec3 rndXz)
        {
            this.initial = initial;
            this.delta = delta;
            this.rndXz = rndXz;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Vec3> initial;
            public Field<Mech3DotNet.Types.Common.Vec3> delta;
            public Field<Mech3DotNet.Types.Common.Vec3> rndXz;
        }

        public static void Serialize(ObjectMotionTranslation v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("initial");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.initial);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.delta);
            s.SerializeFieldName("rnd_xz");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.rndXz);
        }

        public static ObjectMotionTranslation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                initial = new Field<Mech3DotNet.Types.Common.Vec3>(),
                delta = new Field<Mech3DotNet.Types.Common.Vec3>(),
                rndXz = new Field<Mech3DotNet.Types.Common.Vec3>(),
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
                    case "rnd_xz":
                        fields.rndXz.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionTranslation", fieldName);
                }
            }
            return new ObjectMotionTranslation(

                fields.initial.Unwrap("ObjectMotionTranslation", "initial"),

                fields.delta.Unwrap("ObjectMotionTranslation", "delta"),

                fields.rndXz.Unwrap("ObjectMotionTranslation", "rndXz")

            );
        }
    }
}
