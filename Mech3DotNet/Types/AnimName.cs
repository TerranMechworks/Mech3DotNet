using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class AnimName
    {
        public static readonly TypeConverter<AnimName> Converter = new TypeConverter<AnimName>(Deserialize, Serialize);
        public string name;
        public byte[] pad;
        public uint unknown;

        public AnimName(string name, byte[] pad, uint unknown)
        {
            this.name = name;
            this.pad = pad;
            this.unknown = unknown;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<byte[]> pad;
            public Field<uint> unknown;
        }

        public static void Serialize(AnimName v, Serializer s)
        {
            s.SerializeStruct("AnimName", 3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pad");
            ((Action<byte[]>)s.SerializeBytes)(v.pad);
            s.SerializeFieldName("unknown");
            ((Action<uint>)s.SerializeU32)(v.unknown);
        }

        public static AnimName Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                pad = new Field<byte[]>(),
                unknown = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("AnimName"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "pad":
                        fields.pad.Value = d.DeserializeBytes();
                        break;
                    case "unknown":
                        fields.unknown.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("AnimName", fieldName);
                }
            }
            return new AnimName(

                fields.name.Unwrap("AnimName", "name"),

                fields.pad.Unwrap("AnimName", "pad"),

                fields.unknown.Unwrap("AnimName", "unknown")

            );
        }
    }
}
