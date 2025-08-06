using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class BounceSound
    {
        public string name;
        public float volume;

        public BounceSound(string name, float volume)
        {
            this.name = name;
            this.volume = volume;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<BounceSound> Converter = new TypeConverter<BounceSound>(Deserialize, Serialize);

        public static void Serialize(BounceSound v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("volume");
            ((Action<float>)s.SerializeF32)(v.volume);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<float> volume;
        }

        public static BounceSound Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                volume = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "volume":
                        fields.volume.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("BounceSound", fieldName);
                }
            }
            return new BounceSound(

                fields.name.Unwrap("BounceSound", "name"),

                fields.volume.Unwrap("BounceSound", "volume")

            );
        }

        #endregion
    }
}
