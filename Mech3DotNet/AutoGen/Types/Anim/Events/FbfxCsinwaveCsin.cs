using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FbfxCsinwaveCsin
    {
        public Mech3DotNet.Types.Anim.Events.FloatFromTo x;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo y;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo z;

        public FbfxCsinwaveCsin(Mech3DotNet.Types.Anim.Events.FloatFromTo x, Mech3DotNet.Types.Anim.Events.FloatFromTo y, Mech3DotNet.Types.Anim.Events.FloatFromTo z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<FbfxCsinwaveCsin> Converter = new TypeConverter<FbfxCsinwaveCsin>(Deserialize, Serialize);

        public static void Serialize(FbfxCsinwaveCsin v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("x");
            s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)(v.x);
            s.SerializeFieldName("y");
            s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)(v.y);
            s.SerializeFieldName("z");
            s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)(v.z);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo> x;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo> y;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo> z;
        }

        public static FbfxCsinwaveCsin Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo>(),
                y = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo>(),
                z = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo>(),
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
                    case "z":
                        fields.z.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("FbfxCsinwaveCsin", fieldName);
                }
            }
            return new FbfxCsinwaveCsin(

                fields.x.Unwrap("FbfxCsinwaveCsin", "x"),

                fields.y.Unwrap("FbfxCsinwaveCsin", "y"),

                fields.z.Unwrap("FbfxCsinwaveCsin", "z")

            );
        }

        #endregion
    }
}
