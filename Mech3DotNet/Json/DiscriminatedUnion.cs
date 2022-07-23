using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using static Mech3DotNet.Json.Helpers;

namespace Mech3DotNet.Json
{
    public interface IDiscriminatedUnion
    {
        bool Is<T>() where T : class;
        T As<T>() where T : class;
        object GetValue();
    }

    public class DiscriminatedUnion : IDiscriminatedUnion
    {
        protected object value;
        public bool Is<T>() where T : class { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() where T : class { return (T)value; }
        public object GetValue() { return value; }
    }

    public class DiscriminatedUnionException : Exception
    {
        public DiscriminatedUnionException(string message) : base(message) { }
    }

    public class DiscriminatedUnionMissingConstructorException : DiscriminatedUnionException
    {
        public DiscriminatedUnionMissingConstructorException(string message) : base(message) { }
    }

    public class DiscriminatedUnionConverter<T> : JsonConverter where T : IDiscriminatedUnion
    {
        protected class Introspector
        {
            public readonly Type type;
            public readonly Dictionary<string, Type> namesToTypes;
            public readonly Dictionary<Type, string> typesToNames;
            public readonly Dictionary<Type, ConstructorInfo> constructors;
            public readonly List<string> hasNoValue;

            public Introspector()
            {
                type = typeof(T);

                // find the constructors first, so we can throw an exception if
                // a constructor isn't found for a nested class
                var ctorsByType = new Dictionary<Guid, ConstructorInfo>();
                foreach (var ctorInfo in type.GetConstructors())
                {
                    var paramInfos = ctorInfo.GetParameters();
                    if (paramInfos.Length == 1)
                        ctorsByType.Add(paramInfos[0].ParameterType.GUID, ctorInfo);
                }

                namesToTypes = new Dictionary<string, Type>();
                typesToNames = new Dictionary<Type, string>();
                constructors = new Dictionary<Type, ConstructorInfo>();
                hasNoValue = new List<string>();

                //foreach (var t in type.GetNestedTypes())
                var nestedTypes = new List<Type>();
                var currentType = type;
                while (currentType != null)
                {
                    var nested = currentType.GetNestedTypes();
                    if (currentType.IsGenericType && !type.IsGenericTypeDefinition)
                    {
                        var genericArgs = currentType.GetGenericArguments();
                        foreach (var nestedType in nested)
                        {
                            if (nestedType.IsGenericType && nestedType.IsGenericTypeDefinition)
                                nestedTypes.Add(nestedType.MakeGenericType(currentType.GetGenericArguments()));
                            else
                                nestedTypes.Add(nestedType);
                        }
                    }
                    else
                        nestedTypes.AddRange(nested);
                    currentType = currentType.BaseType;
                }

                foreach (var t in nestedTypes)
                {
                    if (t.IsClass)
                    {
                        ConstructorInfo ctorInfo;
                        try
                        {
                            ctorInfo = ctorsByType[t.GUID];
                        }
                        catch (KeyNotFoundException)
                        {
                            throw new DiscriminatedUnionMissingConstructorException(
                                $"Type '{type}' contains no constructor for '{t}'");
                        }
                        namesToTypes.Add(t.Name, t);
                        typesToNames.Add(t, t.Name);
                        constructors.Add(t, ctorInfo);
                        if (t.GetFields().Length == 0)
                            hasNoValue.Add(t.Name);
                    }
                }
            }

            public object CallConstructor(Type type, object value)
            {
                return constructors[type].Invoke(new object[] { value });
            }
        }

        protected static Introspector introspector = new Introspector();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                return ReadMemberWithoutValues(reader, objectType, serializer);
            return ReadMemberWithValues(reader, objectType, serializer);
        }

        private object ReadMemberWithoutValues(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            var memberName = (string)reader.Value;
            Type memberType = null;
            try
            {
                memberType = introspector.namesToTypes[memberName];
            }
            catch (KeyNotFoundException ex)
            {
                throw new JsonSerializationException(
                    AddPath(reader, $"Invalid discriminant '{memberName}' for {introspector.type.Name}"), ex);
            }
            if (!introspector.hasNoValue.Contains(memberName))
                throw new JsonSerializationException(
                    AddPath(reader, $"Discriminant '{memberName}' for {introspector.type.Name} requires values"));
            var memberValue = Activator.CreateInstance(memberType);
            return introspector.CallConstructor(memberType, memberValue);

        }

        private object ReadMemberWithValues(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException(
                    AddPath(reader, $"Unexpected token when deserializing object: {reader.TokenType}"));

            if (!reader.Read())
                throw new JsonSerializationException(
                    AddPath(reader, "Unexpected end when reading JSON"));

            // I don't know if this is allowed to happen?
            if (reader.TokenType != JsonToken.PropertyName)
                throw new JsonSerializationException(
                    AddPath(reader, $"Unexpected token when deserializing object: {reader.TokenType}"));

            string memberName = null;
            try
            {
                memberName = (string)reader.Value;
            }
            catch (InvalidCastException ex)
            {
                // we're not really converting, but oh well...
                throw new JsonSerializationException(
                    AddPath(reader, $"Error converting value {reader.Value} to type 'string'"), ex);
            }

            Type memberType = null;
            try
            {
                memberType = introspector.namesToTypes[memberName];
            }
            catch (KeyNotFoundException ex)
            {
                throw new JsonSerializationException(
                    AddPath(reader, $"Invalid discriminant '{memberName}' for {introspector.type.Name}"), ex);
            }

            if (introspector.hasNoValue.Contains(memberName))
                throw new JsonSerializationException(
                    AddPath(reader, $"Discriminant '{memberName}' for {introspector.type.Name} has no values"));

            if (!reader.Read())
                throw new JsonSerializationException(
                    AddPath(reader, "Unexpected end when deserializing object"));

            var memberValue = serializer.Deserialize(reader, memberType);

            if (!reader.Read())
                throw new JsonSerializationException(
                    AddPath(reader, "Unexpected end when deserializing object"));

            if (reader.TokenType != JsonToken.EndObject)
                throw new JsonReaderException(
                    AddPath(reader, $"Too many elements for {introspector.type.Name}"));

            return introspector.CallConstructor(memberType, memberValue);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var memberValue = ((T)value).GetValue();
            var memberType = memberValue.GetType();
            var memberName = introspector.typesToNames[memberType];

            if (introspector.hasNoValue.Contains(memberName))
                writer.WriteValue(memberName);
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName(memberName);
                serializer.Serialize(writer, memberValue);
                writer.WriteEndObject();
            }
        }

        public override bool CanRead { get { return true; } }
        public override bool CanWrite { get { return true; } }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
    }
}
