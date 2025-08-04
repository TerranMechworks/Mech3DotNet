using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FbfxCsinwaveScreenPos
    {
        public static readonly TypeConverter<FbfxCsinwaveScreenPos> Converter = new TypeConverter<FbfxCsinwaveScreenPos>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.FloatFromTo x;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo y;

        public FbfxCsinwaveScreenPos(Mech3DotNet.Types.Anim.Events.FloatFromTo x, Mech3DotNet.Types.Anim.Events.FloatFromTo y)
        {
            this.x = x;
            this.y = y;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo> x;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo> y;
        }

        public static void Serialize(FbfxCsinwaveScreenPos v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("x");
            s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)(v.x);
            s.SerializeFieldName("y");
            s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)(v.y);
        }

        public static FbfxCsinwaveScreenPos Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo>(),
                y = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "x":
                        fields.x.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)();
                        break;
                    case "y":
                        fields.y.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("FbfxCsinwaveScreenPos", fieldName);
                }
            }
            return new FbfxCsinwaveScreenPos(

                fields.x.Unwrap("FbfxCsinwaveScreenPos", "x"),

                fields.y.Unwrap("FbfxCsinwaveScreenPos", "y")

            );
        }
    }
}
