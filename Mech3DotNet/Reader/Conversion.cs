using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;
using static Mech3DotNet.Reader.Helpers;

namespace Mech3DotNet.Reader
{
    public interface IReaderConverter
    {
        object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path);
        Type ConvertType { get; }
    }

    public interface IReaderConverter<T>
    {
        T ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path);
    }

    public static class Convert
    {
        public static Map<U> Map<U>(IReaderConverter<U> converter)
        {
            return new Map<U>(converter);
        }

        public static ToString String()
        {
            return new ToString();
        }

        public static ToInt Int()
        {
            return new ToInt();
        }

        public static ToFloat Float()
        {
            return new ToFloat();
        }

        public static ToClassLenient<U> Class<U>()
        {
            return new ToClassLenient<U>();
        }

        public static ToStruct<U> Struct<U>()
        {
            return new ToStruct<U>();
        }

        public static Token Token()
        {
            return new Token();
        }
    }

    public struct Token : IReaderConverter<JToken>
    {
        public JToken ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return token;
        }

        public static JToken operator /(Query query, Token converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }

    public struct ToString : IReaderConverter, IReaderConverter<string>
    {
        public string ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return (string)UnpackSingleValueFromArray(token, JTokenType.String, path);
        }

        public object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return ConvertTo(deserializer, token, path);
        }

        public Type ConvertType
        {
            get { return typeof(string); }
        }

        public static string operator /(Query query, ToString converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }

    public struct ToInt : IReaderConverter, IReaderConverter<int>
    {
        public int ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return (int)UnpackSingleValueFromArray(token, JTokenType.Integer, path);
        }

        public object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return ConvertTo(deserializer, token, path);
        }

        public Type ConvertType
        {
            get { return typeof(int); }
        }

        public static int operator /(Query query, ToInt converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }

    public struct ToFloat : IReaderConverter, IReaderConverter<float>
    {
        public float ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return (float)UnpackSingleValueFromArray(token, JTokenType.Float, path);
        }

        public object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return ConvertTo(deserializer, token, path);
        }

        public Type ConvertType
        {
            get { return typeof(float); }
        }

        public static float operator /(Query query, ToFloat converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }

    public struct Map<T> : IReaderConverter, IReaderConverter<List<T>>
    {
        private IReaderConverter<T> converter;

        public Map(IReaderConverter<T> converter)
        {
            this.converter = converter;
        }

        public List<T> ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            var array = InvalidTypeException.Array(token, path);
            var result = new List<T>(array.Count);
            var index = 0;
            foreach (var child in array)
            {
                var childPath = ExtendPath(path, index.ToString());
                result.Add(this.converter.ConvertTo(deserializer, child, childPath));
                index++;
            }
            return result;
        }

        public object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return ConvertTo(deserializer, token, path);
        }

        public Type ConvertType
        {
            get { return typeof(List<T>); }
        }

        public static List<T> operator /(Query query, Map<T> converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }

    public struct ToList<T> : IReaderConverter, IReaderConverter<List<T>>
    {
        public List<T> ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            var array = InvalidTypeException.Array(token, path);
            var result = new List<T>(array.Count);
            var index = 0;
            foreach (var child in array)
            {
                var childPath = ExtendPath(path, index.ToString());
                result.Add(deserializer.Deserialize<T>(child, childPath));
                index++;
            }
            return result;
        }

        public object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return ConvertTo(deserializer, token, path);
        }

        public Type ConvertType
        {
            get { return typeof(List<T>); }
        }

        public static List<T> operator /(Query query, ToList<T> converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }

    public class ToClass<T> : IReaderConverter, IReaderConverter<T>
    {
        protected class Introspector
        {
            public readonly Type type;
            public readonly Dictionary<string, FieldInfo> fieldInfos;
            public readonly ConstructorInfo constructor;

            public Introspector()
            {
                type = typeof(T);

                fieldInfos = new Dictionary<string, FieldInfo>();
                foreach (var fieldInfo in type.GetFields())
                    fieldInfos.Add(fieldInfo.Name, fieldInfo);

                constructor = null;
                foreach (var ctorInfo in type.GetConstructors())
                {
                    var paramInfos = ctorInfo.GetParameters();
                    if (paramInfos.Length == 0)
                    {
                        constructor = ctorInfo;
                        break;
                    }
                }

                if (constructor == null)
                    throw new NoConstructorException($"No parameterless constructor found for '{type.Name}'");
            }
        }

        protected static Introspector introspector = new Introspector();

        private bool skipUnknown;
        private bool requireAll;

        public ToClass(bool skipUnknown, bool requireAll)
        {
            this.skipUnknown = skipUnknown;
            this.requireAll = requireAll;
        }

        public T ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            var array = InvalidTypeException.Array(token, path);
            var inst = introspector.constructor.Invoke(null);
#if NETSTANDARD
            var processed = new HashSet<string>(introspector.fieldInfos.Keys);
#else
            var processed = new List<string>(introspector.fieldInfos.Keys);
#endif

            string key = null;
            List<string> keyPath = null;
            var index = 0;
            foreach (var child in array)
            {
                var childPath = ExtendPath(path, index.ToString());
                if (key == null)
                {
                    keyPath = childPath;
                    key = InvalidTypeException.String(child, keyPath);
                }
                else
                {
                    var fieldName = key;
                    // no matter which path we take, the next value should be read as a key again
                    key = null;

                    FieldInfo fieldInfo = null;
                    if (!introspector.fieldInfos.TryGetValue(fieldName, out fieldInfo))
                    {
                        if (this.skipUnknown)
                            continue;
                        throw new UnknownFieldException(AddPath($"No field '{fieldName}' on type '{introspector.type.Name}'", keyPath));
                    }
                    keyPath = null;

                    var fieldValue = deserializer.Deserialize(child, fieldInfo.FieldType, childPath);
                    fieldInfo.SetValue(inst, fieldValue);
                    processed.Remove(fieldName);
                }
                index++;
            }

            if (key != null && !this.skipUnknown)
                throw new ConversionException(AddPath($"Key '{key}' without value", keyPath));

            if (this.requireAll && processed.Count > 0)
            {
#if NETSTANDARD
                var fields = string.Join(",", processed);
#else
                var fields = string.Join(",", processed.ToArray());
#endif
                throw new RequiredFieldsException(AddPath($"Fields '{fields}' not set on type '{introspector.type.Name}'", path));
            }

            return (T)inst;
        }

        public object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return ConvertTo(deserializer, token, path);
        }

        public Type ConvertType
        {
            get { return introspector.type; }
        }

        public static T operator /(Query query, ToClass<T> converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }

    public class ToClassStrict<T> : ToClass<T>
    {
        public ToClassStrict() : base(false, true) { }
    }

    public class ToClassLenient<T> : ToClass<T>
    {
        public ToClassLenient() : base(true, false) { }
    }

    public class ToStruct<T> : IReaderConverter, IReaderConverter<T>
    {
        protected class Introspector
        {
            public readonly Type type;
            public readonly int fieldCount;
            public readonly List<FieldInfo> fieldInfos;
            public readonly ConstructorInfo constructor;

            public Introspector()
            {
                type = typeof(T);

                fieldInfos = new List<FieldInfo>();
                // fields seem to be in the order they're declared (which is good)
                foreach (var fieldInfo in type.GetFields())
                    fieldInfos.Add(fieldInfo);
                fieldCount = fieldInfos.Count;

                constructor = null;
                foreach (var ctorInfo in type.GetConstructors())
                {
                    var paramInfos = ctorInfo.GetParameters();
                    if (fieldCount == paramInfos.Length)
                    {
                        bool matches = true;
                        for (var i = 0; i < fieldCount; i++)
                        {
                            if (fieldInfos[i].FieldType != paramInfos[i].ParameterType)
                            {
                                matches = false;
                                break;
                            }
                        }
                        if (matches)
                        {
                            constructor = ctorInfo;
                            break;
                        }
                    }
                }

                if (constructor == null)
                    throw new NoConstructorException($"No parameterless constructor found for '{type.Name}'");
            }
        }

        protected static Introspector introspector = new Introspector();

        public ToStruct() { }

        public T ConvertTo(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            var array = InvalidTypeException.Array(token, path);
            if (array.Count != introspector.fieldCount)
                throw new ConversionException(AddPath($"Expected {introspector.fieldCount} fields, but found {array.Count} fields", path));

            var parameters = new List<object>(introspector.fieldCount);
            for (var i = 0; i < introspector.fieldCount; i++)
            {
                var fieldInfo = introspector.fieldInfos[i];
                var child = array[i];
                var childPath = ExtendPath(path, i.ToString());
                var fieldValue = deserializer.Deserialize(child, fieldInfo.FieldType, childPath);
                parameters.Add(fieldValue);
            }

            return (T)introspector.constructor.Invoke(parameters.ToArray());
        }

        public object Convert(ReaderDeserializer deserializer, JToken token, IEnumerable<string> path)
        {
            return ConvertTo(deserializer, token, path);
        }

        public Type ConvertType
        {
            get { return introspector.type; }
        }

        public static T operator /(Query query, ToStruct<T> converter)
        {
            return converter.ConvertTo(query.deserializer, query.token, query.path);
        }
    }
}
