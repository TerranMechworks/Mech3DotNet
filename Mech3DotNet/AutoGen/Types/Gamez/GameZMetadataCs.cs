using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZMetadataCs
    {
        public static readonly TypeConverter<GameZMetadataCs> Converter = new TypeConverter<GameZMetadataCs>(Deserialize, Serialize);
        public System.DateTime datetime;
        public System.Collections.Generic.List<uint?> texturePtrs;

        public GameZMetadataCs(System.DateTime datetime, System.Collections.Generic.List<uint?> texturePtrs)
        {
            this.datetime = datetime;
            this.texturePtrs = texturePtrs;
        }

        private struct Fields
        {
            public Field<System.DateTime> datetime;
            public Field<System.Collections.Generic.List<uint?>> texturePtrs;
        }

        public static void Serialize(GameZMetadataCs v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("datetime");
            ((Action<DateTime>)s.SerializeDateTime)(v.datetime);
            s.SerializeFieldName("texture_ptrs");
            s.SerializeVec(s.SerializeValOption(((Action<uint>)s.SerializeU32)))(v.texturePtrs);
        }

        public static GameZMetadataCs Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                datetime = new Field<System.DateTime>(),
                texturePtrs = new Field<System.Collections.Generic.List<uint?>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "datetime":
                        fields.datetime.Value = d.DeserializeDateTime();
                        break;
                    case "texture_ptrs":
                        fields.texturePtrs.Value = d.DeserializeVec(d.DeserializeValOption(d.DeserializeU32))();
                        break;
                    default:
                        throw new UnknownFieldException("GameZMetadataCs", fieldName);
                }
            }
            return new GameZMetadataCs(

                fields.datetime.Unwrap("GameZMetadataCs", "datetime"),

                fields.texturePtrs.Unwrap("GameZMetadataCs", "texturePtrs")

            );
        }
    }
}
