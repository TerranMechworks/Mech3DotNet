using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Else
    {
        public static readonly TypeConverter<Else> Converter = new TypeConverter<Else>(Deserialize, Serialize);

        public Else()
        {
        }

        private struct Fields
        {
        }

        public static void Serialize(Else v, Serializer s)
        {
            s.SerializeStruct("Else", 0);
        }

        public static Else Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
            };
            foreach (var fieldName in d.DeserializeStruct("Else"))
            {
                switch (fieldName)
                {
                    default:
                        throw new UnknownFieldException("Else", fieldName);
                }
            }
            return new Else(

            );
        }
    }
}
