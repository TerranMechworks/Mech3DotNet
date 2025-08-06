using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public sealed class AnimDefFile
    {
        public string name;
        public System.DateTime datetime;
        public uint? hash = null;

        public AnimDefFile(string name, System.DateTime datetime, uint? hash)
        {
            this.name = name;
            this.datetime = datetime;
            this.hash = hash;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<AnimDefFile> Converter = new TypeConverter<AnimDefFile>(Deserialize, Serialize);

        public static void Serialize(AnimDefFile v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("datetime");
            ((Action<DateTime>)s.SerializeDateTime)(v.datetime);
            s.SerializeFieldName("hash");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.hash);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<System.DateTime> datetime;
            public Field<uint?> hash;
        }

        public static AnimDefFile Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                datetime = new Field<System.DateTime>(),
                hash = new Field<uint?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "datetime":
                        fields.datetime.Value = d.DeserializeDateTime();
                        break;
                    case "hash":
                        fields.hash.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    default:
                        throw new UnknownFieldException("AnimDefFile", fieldName);
                }
            }
            return new AnimDefFile(

                fields.name.Unwrap("AnimDefFile", "name"),

                fields.datetime.Unwrap("AnimDefFile", "datetime"),

                fields.hash.Unwrap("AnimDefFile", "hash")

            );
        }

        #endregion
    }
}
