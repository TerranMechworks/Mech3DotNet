using System.Collections.Generic;

namespace Mech3DotNet.Exchange
{
    /// <summary>Serializer and deserializer options.</summary>
    public static class Options
    {
        public static List<TypeConverter> DefaultConverters = GetDefaultConverters();

        public static List<TypeConverter> GetDefaultConverters() => new List<TypeConverter>
        {
            TypeConverter.From(Mech3DotNet.Types.Common.QuaternionConverter.Converter),
            TypeConverter.From(Mech3DotNet.Types.Common.Vec3Converter.Converter),
        };
    }
}
