using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Else
    {

        public Else()
        {
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<Else> Converter = new TypeConverter<Else>(Deserialize, Serialize);

        public static void Serialize(Else v, Serializer s)
        {
            s.SerializeStruct(0);
        }

        private struct Fields
        {
        }

        public static Else Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
            };
            foreach (var fieldName in d.DeserializeStruct())
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

        #endregion
    }
}
