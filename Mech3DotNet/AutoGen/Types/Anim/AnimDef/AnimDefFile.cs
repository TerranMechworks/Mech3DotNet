using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public sealed class AnimDefFile
    {
        public string name;
        public System.DateTime datetime;
        public byte[]? garbage = null;

        public AnimDefFile(string name, System.DateTime datetime, byte[]? garbage)
        {
            this.name = name;
            this.datetime = datetime;
            this.garbage = garbage;
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
            s.SerializeFieldName("garbage");
            s.SerializeRefOption(((Action<byte[]>)s.SerializeBytes))(v.garbage);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<System.DateTime> datetime;
            public Field<byte[]?> garbage;
        }

        public static AnimDefFile Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                datetime = new Field<System.DateTime>(),
                garbage = new Field<byte[]?>(null),
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
                    case "garbage":
                        fields.garbage.Value = d.DeserializeRefOption(d.DeserializeBytes)();
                        break;
                    default:
                        throw new UnknownFieldException("AnimDefFile", fieldName);
                }
            }
            return new AnimDefFile(

                fields.name.Unwrap("AnimDefFile", "name"),

                fields.datetime.Unwrap("AnimDefFile", "datetime"),

                fields.garbage.Unwrap("AnimDefFile", "garbage")

            );
        }

        #endregion
    }
}
