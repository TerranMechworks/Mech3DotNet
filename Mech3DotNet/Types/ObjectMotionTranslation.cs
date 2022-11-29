using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionTranslation
    {
        public static readonly TypeConverter<ObjectMotionTranslation> Converter = new TypeConverter<ObjectMotionTranslation>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Vec3 delta;
        public Mech3DotNet.Types.Types.Vec3 initial;
        public Mech3DotNet.Types.Types.Vec3 unk;

        public ObjectMotionTranslation(Mech3DotNet.Types.Types.Vec3 delta, Mech3DotNet.Types.Types.Vec3 initial, Mech3DotNet.Types.Types.Vec3 unk)
        {
            this.delta = delta;
            this.initial = initial;
            this.unk = unk;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Vec3> delta;
            public Field<Mech3DotNet.Types.Types.Vec3> initial;
            public Field<Mech3DotNet.Types.Types.Vec3> unk;
        }

        public static void Serialize(ObjectMotionTranslation v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.delta);
            s.SerializeFieldName("initial");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.initial);
            s.SerializeFieldName("unk");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.unk);
        }

        public static ObjectMotionTranslation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                delta = new Field<Mech3DotNet.Types.Types.Vec3>(),
                initial = new Field<Mech3DotNet.Types.Types.Vec3>(),
                unk = new Field<Mech3DotNet.Types.Types.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "delta":
                        fields.delta.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "initial":
                        fields.initial.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "unk":
                        fields.unk.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionTranslation", fieldName);
                }
            }
            return new ObjectMotionTranslation(

                fields.delta.Unwrap("ObjectMotionTranslation", "delta"),

                fields.initial.Unwrap("ObjectMotionTranslation", "initial"),

                fields.unk.Unwrap("ObjectMotionTranslation", "unk")

            );
        }
    }
}
