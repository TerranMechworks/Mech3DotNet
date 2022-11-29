using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionScale
    {
        public static readonly TypeConverter<ObjectMotionScale> Converter = new TypeConverter<ObjectMotionScale>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Vec3 value;
        public Mech3DotNet.Types.Types.Vec3 unk;

        public ObjectMotionScale(Mech3DotNet.Types.Types.Vec3 value, Mech3DotNet.Types.Types.Vec3 unk)
        {
            this.value = value;
            this.unk = unk;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Vec3> value;
            public Field<Mech3DotNet.Types.Types.Vec3> unk;
        }

        public static void Serialize(ObjectMotionScale v, Serializer s)
        {
            s.SerializeStruct("ObjectMotionScale", 2);
            s.SerializeFieldName("value");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.value);
            s.SerializeFieldName("unk");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.unk);
        }

        public static ObjectMotionScale Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<Mech3DotNet.Types.Types.Vec3>(),
                unk = new Field<Mech3DotNet.Types.Types.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ObjectMotionScale"))
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "unk":
                        fields.unk.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionScale", fieldName);
                }
            }
            return new ObjectMotionScale(

                fields.value.Unwrap("ObjectMotionScale", "value"),

                fields.unk.Unwrap("ObjectMotionScale", "unk")

            );
        }
    }
}
