using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FrameBufferEffectColor
    {
        public static readonly TypeConverter<FrameBufferEffectColor> Converter = new TypeConverter<FrameBufferEffectColor>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.Rgba from;
        public Mech3DotNet.Types.Anim.Events.Rgba to;
        public float runtime;
        public bool fudgeAlpha = false;

        public FrameBufferEffectColor(Mech3DotNet.Types.Anim.Events.Rgba from, Mech3DotNet.Types.Anim.Events.Rgba to, float runtime, bool fudgeAlpha)
        {
            this.from = from;
            this.to = to;
            this.runtime = runtime;
            this.fudgeAlpha = fudgeAlpha;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.Rgba> from;
            public Field<Mech3DotNet.Types.Anim.Events.Rgba> to;
            public Field<float> runtime;
            public Field<bool> fudgeAlpha;
        }

        public static void Serialize(FrameBufferEffectColor v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("from");
            s.Serialize(Mech3DotNet.Types.Anim.Events.RgbaConverter.Converter)(v.from);
            s.SerializeFieldName("to");
            s.Serialize(Mech3DotNet.Types.Anim.Events.RgbaConverter.Converter)(v.to);
            s.SerializeFieldName("runtime");
            ((Action<float>)s.SerializeF32)(v.runtime);
            s.SerializeFieldName("fudge_alpha");
            ((Action<bool>)s.SerializeBool)(v.fudgeAlpha);
        }

        public static FrameBufferEffectColor Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                from = new Field<Mech3DotNet.Types.Anim.Events.Rgba>(),
                to = new Field<Mech3DotNet.Types.Anim.Events.Rgba>(),
                runtime = new Field<float>(),
                fudgeAlpha = new Field<bool>(false),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "from":
                        fields.from.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.RgbaConverter.Converter)();
                        break;
                    case "to":
                        fields.to.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.RgbaConverter.Converter)();
                        break;
                    case "runtime":
                        fields.runtime.Value = d.DeserializeF32();
                        break;
                    case "fudge_alpha":
                        fields.fudgeAlpha.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("FrameBufferEffectColor", fieldName);
                }
            }
            return new FrameBufferEffectColor(

                fields.from.Unwrap("FrameBufferEffectColor", "from"),

                fields.to.Unwrap("FrameBufferEffectColor", "to"),

                fields.runtime.Unwrap("FrameBufferEffectColor", "runtime"),

                fields.fudgeAlpha.Unwrap("FrameBufferEffectColor", "fudgeAlpha")

            );
        }
    }
}
