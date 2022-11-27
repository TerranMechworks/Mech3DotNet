using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class BoundingBox
    {
        public static readonly TypeConverter<BoundingBox> Converter = new TypeConverter<BoundingBox>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Vec3 a;
        public Mech3DotNet.Types.Types.Vec3 b;

        public BoundingBox(Mech3DotNet.Types.Types.Vec3 a, Mech3DotNet.Types.Types.Vec3 b)
        {
            this.a = a;
            this.b = b;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Vec3> a;
            public Field<Mech3DotNet.Types.Types.Vec3> b;
        }

        public static void Serialize(Mech3DotNet.Types.Nodes.BoundingBox v, Serializer s)
        {
            s.SerializeStruct("BoundingBox", 2);
            s.SerializeFieldName("a");
            s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter)(v.a);
            s.SerializeFieldName("b");
            s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter)(v.b);
        }

        public static Mech3DotNet.Types.Nodes.BoundingBox Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                a = new Field<Mech3DotNet.Types.Types.Vec3>(),
                b = new Field<Mech3DotNet.Types.Types.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct("BoundingBox"))
            {
                switch (fieldName)
                {
                    case "a":
                        fields.a.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter)();
                        break;
                    case "b":
                        fields.b.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("BoundingBox", fieldName);
                }
            }
            return new BoundingBox(

                fields.a.Unwrap("BoundingBox", "a"),

                fields.b.Unwrap("BoundingBox", "b")

            );
        }
    }
}
