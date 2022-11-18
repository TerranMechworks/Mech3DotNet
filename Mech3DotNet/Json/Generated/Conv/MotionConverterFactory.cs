using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Motion.Converters
{
    public class MotionConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(System.Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
                return false;
            if (typeToConvert.GetGenericTypeDefinition() != typeof(Motion<,>))
                return false;
            return true;
        }

        public override JsonConverter CreateConverter(System.Type type, JsonSerializerOptions options)
        {
            return (JsonConverter)Activator.CreateInstance(
                typeof(MotionConverter<,>).MakeGenericType(type.GetGenericArguments()),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null)!;
        }
    }
}
