using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Endif
    {
        public static readonly TypeConverter<Endif> Converter = new TypeConverter<Endif>(Deserialize, Serialize);

        public Endif()
        {
        }

        private struct Fields
        {
        }

        public static void Serialize(Endif v, Serializer s)
        {
            s.SerializeStruct(0);
        }

        public static Endif Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    default:
                        throw new UnknownFieldException("Endif", fieldName);
                }
            }
            return new Endif(

            );
        }
    }
}
