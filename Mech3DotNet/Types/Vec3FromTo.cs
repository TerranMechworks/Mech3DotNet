using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Vec3FromTo
    {
        public static readonly TypeConverter<Vec3FromTo> Converter = new TypeConverter<Vec3FromTo>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Vec3 from;
        public Mech3DotNet.Types.Types.Vec3 to;
        public Mech3DotNet.Types.Types.Vec3 delta;

        public Vec3FromTo(Mech3DotNet.Types.Types.Vec3 from, Mech3DotNet.Types.Types.Vec3 to, Mech3DotNet.Types.Types.Vec3 delta)
        {
            this.from = from;
            this.to = to;
            this.delta = delta;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Vec3> from;
            public Field<Mech3DotNet.Types.Types.Vec3> to;
            public Field<Mech3DotNet.Types.Types.Vec3> delta;
        }

        public static void Serialize(Vec3FromTo v, Serializer s)
        {
            s.SerializeStruct("Vec3FromTo", 3);
            s.SerializeFieldName("from");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.from);
            s.SerializeFieldName("to");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.to);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.delta);
        }

        public static Vec3FromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                from = new Field<Mech3DotNet.Types.Types.Vec3>(),
                to = new Field<Mech3DotNet.Types.Types.Vec3>(),
                delta = new Field<Mech3DotNet.Types.Types.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Vec3FromTo"))
            {
                switch (fieldName)
                {
                    case "from":
                        fields.from.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "to":
                        fields.to.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    case "delta":
                        fields.delta.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("Vec3FromTo", fieldName);
                }
            }
            return new Vec3FromTo(

                fields.from.Unwrap("Vec3FromTo", "from"),

                fields.to.Unwrap("Vec3FromTo", "to"),

                fields.delta.Unwrap("Vec3FromTo", "delta")

            );
        }
    }
}
