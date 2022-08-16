using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Converters
{
    public class MotionFrameConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
                return false;
            if (typeToConvert.GetGenericTypeDefinition() != typeof(MotionFrame<,>))
                return false;
            return true;
        }

        public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
        {
            return (JsonConverter)Activator.CreateInstance(
                typeof(MotionFrameConverter<,>).MakeGenericType(type.GetGenericArguments()),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null)!;
        }
    }
}