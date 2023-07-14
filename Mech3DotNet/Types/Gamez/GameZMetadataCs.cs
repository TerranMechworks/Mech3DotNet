using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZMetadataCs
    {
        public static readonly TypeConverter<GameZMetadataCs> Converter = new TypeConverter<GameZMetadataCs>(Deserialize, Serialize);
        public uint gamezHeaderUnk08;
        public System.Collections.Generic.List<uint?> texturePtrs;

        public GameZMetadataCs(uint gamezHeaderUnk08, System.Collections.Generic.List<uint?> texturePtrs)
        {
            this.gamezHeaderUnk08 = gamezHeaderUnk08;
            this.texturePtrs = texturePtrs;
        }

        private struct Fields
        {
            public Field<uint> gamezHeaderUnk08;
            public Field<System.Collections.Generic.List<uint?>> texturePtrs;
        }

        public static void Serialize(GameZMetadataCs v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("gamez_header_unk08");
            ((Action<uint>)s.SerializeU32)(v.gamezHeaderUnk08);
            s.SerializeFieldName("texture_ptrs");
            s.SerializeVec(s.SerializeValOption(((Action<uint>)s.SerializeU32)))(v.texturePtrs);
        }

        public static GameZMetadataCs Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                gamezHeaderUnk08 = new Field<uint>(),
                texturePtrs = new Field<System.Collections.Generic.List<uint?>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "gamez_header_unk08":
                        fields.gamezHeaderUnk08.Value = d.DeserializeU32();
                        break;
                    case "texture_ptrs":
                        fields.texturePtrs.Value = d.DeserializeVec(d.DeserializeValOption(d.DeserializeU32))();
                        break;
                    default:
                        throw new UnknownFieldException("GameZMetadataCs", fieldName);
                }
            }
            return new GameZMetadataCs(

                fields.gamezHeaderUnk08.Unwrap("GameZMetadataCs", "gamezHeaderUnk08"),

                fields.texturePtrs.Unwrap("GameZMetadataCs", "texturePtrs")

            );
        }
    }
}
