using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class BounceSequence
    {
        public static readonly TypeConverter<BounceSequence> Converter = new TypeConverter<BounceSequence>(Deserialize, Serialize);
        public string? seqName0;
        public string? seqName1;
        public string? seqName2;

        public BounceSequence(string? seqName0, string? seqName1, string? seqName2)
        {
            this.seqName0 = seqName0;
            this.seqName1 = seqName1;
            this.seqName2 = seqName2;
        }

        private struct Fields
        {
            public Field<string?> seqName0;
            public Field<string?> seqName1;
            public Field<string?> seqName2;
        }

        public static void Serialize(BounceSequence v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("seq_name0");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.seqName0);
            s.SerializeFieldName("seq_name1");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.seqName1);
            s.SerializeFieldName("seq_name2");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.seqName2);
        }

        public static BounceSequence Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                seqName0 = new Field<string?>(),
                seqName1 = new Field<string?>(),
                seqName2 = new Field<string?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "seq_name0":
                        fields.seqName0.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "seq_name1":
                        fields.seqName1.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "seq_name2":
                        fields.seqName2.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    default:
                        throw new UnknownFieldException("BounceSequence", fieldName);
                }
            }
            return new BounceSequence(

                fields.seqName0.Unwrap("BounceSequence", "seqName0"),

                fields.seqName1.Unwrap("BounceSequence", "seqName1"),

                fields.seqName2.Unwrap("BounceSequence", "seqName2")

            );
        }
    }
}
