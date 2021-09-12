using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using static Mech3DotNet.Reader.Helpers;

namespace Mech3DotNet.Reader
{
    public class ReaderDeserializer
    {
        private Dictionary<Type, IReaderConverter> converters;

        public ReaderDeserializer() : this(new ToString(), new ToInt(), new ToFloat()) { }

        public ReaderDeserializer(params IReaderConverter[] converters)
        {
            this.converters = new Dictionary<Type, IReaderConverter>();
            foreach (var converter in converters)
                this.AddConverter(converter);
        }

        public void AddConverter(IReaderConverter converter)
        {
            var type = converter.ConvertType;
            this.converters.Add(type, converter);
        }

        public object Deserialize(JToken token, Type type, IEnumerable<string> path)
        {
            IReaderConverter converter = null;
            if (this.converters.TryGetValue(type, out converter))
                return converter.Convert(this, token, path);

            throw new UnknownTypeException(AddPath($"Don't know how to deserialize '{type.Name}'", path));
        }

        public T Deserialize<T>(JToken token, IEnumerable<string> path)
        {
            return (T)Deserialize(token, typeof(T), path);
        }
    }
}
