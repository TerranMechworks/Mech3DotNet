using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FbfxColorFromTo
    {
        public static readonly TypeConverter<FbfxColorFromTo> Converter = new TypeConverter<FbfxColorFromTo>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.Rgba from;
        public Mech3DotNet.Types.Anim.Events.Rgba to;
        public float runTime;
        public float? alphaDelta = null;

        public FbfxColorFromTo(Mech3DotNet.Types.Anim.Events.Rgba from, Mech3DotNet.Types.Anim.Events.Rgba to, float runTime, float? alphaDelta)
        {
            this.from = from;
            this.to = to;
            this.runTime = runTime;
            this.alphaDelta = alphaDelta;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.Rgba> from;
            public Field<Mech3DotNet.Types.Anim.Events.Rgba> to;
            public Field<float> runTime;
            public Field<float?> alphaDelta;
        }

        public static void Serialize(FbfxColorFromTo v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("from");
            s.Serialize(Mech3DotNet.Types.Anim.Events.Rgba.Converter)(v.from);
            s.SerializeFieldName("to");
            s.Serialize(Mech3DotNet.Types.Anim.Events.Rgba.Converter)(v.to);
            s.SerializeFieldName("run_time");
            ((Action<float>)s.SerializeF32)(v.runTime);
            s.SerializeFieldName("alpha_delta");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.alphaDelta);
        }

        public static FbfxColorFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                from = new Field<Mech3DotNet.Types.Anim.Events.Rgba>(),
                to = new Field<Mech3DotNet.Types.Anim.Events.Rgba>(),
                runTime = new Field<float>(),
                alphaDelta = new Field<float?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "from":
                        fields.from.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.Rgba.Converter)();
                        break;
                    case "to":
                        fields.to.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.Rgba.Converter)();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeF32();
                        break;
                    case "alpha_delta":
                        fields.alphaDelta.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("FbfxColorFromTo", fieldName);
                }
            }
            return new FbfxColorFromTo(

                fields.from.Unwrap("FbfxColorFromTo", "from"),

                fields.to.Unwrap("FbfxColorFromTo", "to"),

                fields.runTime.Unwrap("FbfxColorFromTo", "runTime"),

                fields.alphaDelta.Unwrap("FbfxColorFromTo", "alphaDelta")

            );
        }
    }
}
