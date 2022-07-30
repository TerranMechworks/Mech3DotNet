using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class TransparentConverter<T> : JsonConverter where T : class
    {
        protected class Introspector
        {
            public readonly Type type;
            public readonly FieldInfo field;
            public readonly ConstructorInfo constructor;

            public Introspector()
            {
                type = typeof(T);
                var fieldInfos = type.GetFields();
                if (fieldInfos.Length != 1)
                    throw new ArgumentException($"Type '{type}' can only have one field");
                field = fieldInfos[0];

                ConstructorInfo? constructor = null;
                foreach (var ctorInfo in type.GetConstructors())
                {
                    var paramInfos = ctorInfo.GetParameters();
                    if (paramInfos.Length == 1 && paramInfos[0].ParameterType == field.FieldType)
                    {
                        constructor = ctorInfo;
                        break;
                    }
                }

                if (constructor == null)
                    throw new ArgumentException(
                        $"Type '{type}' contains no constructor matching all fields");
                this.constructor = constructor;
            }
        }

        protected static Introspector introspector = new Introspector();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var fieldValue = serializer.Deserialize(reader, introspector.field.FieldType);
            return introspector.constructor.Invoke(new object[] { fieldValue });
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var fieldValue = introspector.field.GetValue(value);
            serializer.Serialize(writer, fieldValue);
        }

        public override bool CanRead { get => true; }
        public override bool CanWrite { get => true; }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
    }
}
