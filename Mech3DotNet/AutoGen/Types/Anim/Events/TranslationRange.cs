using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class TranslationRange
    {
        public static readonly TypeConverter<TranslationRange> Converter = new TypeConverter<TranslationRange>(Deserialize, Serialize);
        public Mech3DotNet.Types.Common.Range xz;
        public Mech3DotNet.Types.Common.Range y;
        public Mech3DotNet.Types.Common.Range initial;
        public Mech3DotNet.Types.Common.Range delta;

        public TranslationRange(Mech3DotNet.Types.Common.Range xz, Mech3DotNet.Types.Common.Range y, Mech3DotNet.Types.Common.Range initial, Mech3DotNet.Types.Common.Range delta)
        {
            this.xz = xz;
            this.y = y;
            this.initial = initial;
            this.delta = delta;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Range> xz;
            public Field<Mech3DotNet.Types.Common.Range> y;
            public Field<Mech3DotNet.Types.Common.Range> initial;
            public Field<Mech3DotNet.Types.Common.Range> delta;
        }

        public static void Serialize(TranslationRange v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("xz");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.xz);
            s.SerializeFieldName("y");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.y);
            s.SerializeFieldName("initial");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.initial);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.delta);
        }

        public static TranslationRange Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                xz = new Field<Mech3DotNet.Types.Common.Range>(),
                y = new Field<Mech3DotNet.Types.Common.Range>(),
                initial = new Field<Mech3DotNet.Types.Common.Range>(),
                delta = new Field<Mech3DotNet.Types.Common.Range>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "xz":
                        fields.xz.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "y":
                        fields.y.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "initial":
                        fields.initial.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "delta":
                        fields.delta.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("TranslationRange", fieldName);
                }
            }
            return new TranslationRange(

                fields.xz.Unwrap("TranslationRange", "xz"),

                fields.y.Unwrap("TranslationRange", "y"),

                fields.initial.Unwrap("TranslationRange", "initial"),

                fields.delta.Unwrap("TranslationRange", "delta")

            );
        }
    }
}
