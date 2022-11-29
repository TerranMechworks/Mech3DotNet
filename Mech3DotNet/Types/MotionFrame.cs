using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Motion
{
    public sealed class MotionFrame<TQuaternion, TVec3>
        where TQuaternion : notnull
        where TVec3 : notnull
    {
        public static readonly TypeConverter<MotionFrame<TQuaternion, TVec3>> Converter = new TypeConverter<MotionFrame<TQuaternion, TVec3>>(Deserialize, Serialize);
        public TVec3 translation;
        public TQuaternion rotation;

        public MotionFrame(TVec3 translation, TQuaternion rotation)
        {
            this.translation = translation;
            this.rotation = rotation;
        }

        private struct Fields
        {
            public Field<TVec3> translation;
            public Field<TQuaternion> rotation;
        }

        public static void Serialize(MotionFrame<TQuaternion, TVec3> v, Serializer s)
        {
            s.SerializeStruct("MotionFrame", 2);
            s.SerializeFieldName("translation");
            s.SerializeGeneric<TVec3>()(v.translation);
            s.SerializeFieldName("rotation");
            s.SerializeGeneric<TQuaternion>()(v.rotation);
        }

        public static MotionFrame<TQuaternion, TVec3> Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                translation = new Field<TVec3>(),
                rotation = new Field<TQuaternion>(),
            };
            foreach (var fieldName in d.DeserializeStruct("MotionFrame"))
            {
                switch (fieldName)
                {
                    case "translation":
                        fields.translation.Value = d.DeserializeGeneric<TVec3>()();
                        break;
                    case "rotation":
                        fields.rotation.Value = d.DeserializeGeneric<TQuaternion>()();
                        break;
                    default:
                        throw new UnknownFieldException("MotionFrame", fieldName);
                }
            }
            return new MotionFrame<TQuaternion, TVec3>(

                fields.translation.Unwrap("MotionFrame", "translation"),

                fields.rotation.Unwrap("MotionFrame", "rotation")

            );
        }
    }
}
