using System;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using static Mech3DotNet.Reader.Helpers;

namespace Mech3DotNet.Reader
{
    public class ReaderDeserializer
    {
        private Dictionary<Type, IReaderConverter> converters;

        public ReaderDeserializer()
        {
            this.converters = new Dictionary<Type, IReaderConverter>();
            this.AddConverter(new ToString());
            this.AddConverter(new ToInt());
            this.AddConverter(new ToFloat());
            this.AddConverter(new ToList<string>());
            this.AddConverter(new ToList<int>());
            this.AddConverter(new ToList<float>());
        }

        public void AddConverter(IReaderConverter converter)
        {
            var type = converter.ConvertType;
            this.converters.Add(type, converter);
        }

        public object Deserialize(JToken token, Type type, IEnumerable<string> path)
        {
            {
                IReaderConverter converter = null;
                if (this.converters.TryGetValue(type, out converter))
                    return converter.Convert(this, token, path);
            }

            Attribute[] attrs = new Attribute[] {};
            try
            {
                attrs = Attribute.GetCustomAttributes(type);
            } catch (NotSupportedException) {}
            catch (TypeLoadException) {}

            foreach (var attr in attrs)
            {
                if (attr is ReaderConverter)
                {
                    var converter = ((ReaderConverter)attr).CreateInstance();
                    return converter.Convert(this, token, path);
                }
            }

            throw new UnknownTypeException(AddPath($"Don't know how to deserialize '{type.Name}'", path));
        }

        public T Deserialize<T>(JToken token, IEnumerable<string> path)
        {
            return (T)Deserialize(token, typeof(T), path);
        }
    }
}
