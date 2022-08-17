using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public class ReaderException : Exception
    {
        protected static string AddPath(string message, IEnumerable<string> path)
        {
            var displayPath = string.Join("/", path);
            return $"{message}. Path '{displayPath}'.";
        }

        public ReaderException(string message, IEnumerable<string> path) : base(AddPath(message, path)) { }
        protected ReaderException(string message) : base(message) { }
    }

    public class NotFoundException : ReaderException
    {
        public NotFoundException(string message, IEnumerable<string> path) : base(message, path) { }
    }

    public class ConversionException : ReaderException
    {
        protected static string AddValue(string message, IEnumerable<string> path, ReaderValue value)
        {
            var displayPath = string.Join("/", path);
            return $"{message}. Path '{displayPath}'. Value: {value.ToString()}";
        }

        public ConversionException(string message, IEnumerable<string> path, ReaderValue value) : base(AddValue(message, path, value)) { }
        public ConversionException(string message, IEnumerable<string> path) : base(message, path) { }

        public static ReaderList List(ReaderValue value, IEnumerable<string> path)
        {
            if (value is ReaderList list)
                return list;
            throw new ConversionException("Value is not a list", path, value);
        }

        public static ReaderList ListFixed(ReaderValue value, IEnumerable<string> path, int count)
        {
            if (value is ReaderList list)
            {
                if (list.Count == count)
                    return list;
                throw new ConversionException($"Value is not a list of size {count}", path, value);
            }
            throw new ConversionException("Value is not a list", path, value);
        }

        public static TValue Scalar<TValue>(ReaderValue value, IEnumerable<string> path, string message) where TValue : ReaderValue
        {
            if (value is TValue direct_value)
                return direct_value;
            // it is common for reader data to contain scalar values as a
            // single value in an array. this would be tedious to unpack each
            // time, so this function attempts to unpack such array. this
            // should technically modify the path, but is only used by leaf
            // converters like `ToInt`, where the path is irrelevant since
            // there cannot be further queries/conversions.
            if (value is ReaderList list && list.Count == 1)
            {
                var only = list[0];
                if (only != null && only is TValue nested_value)
                    return nested_value;
            }
            throw new ConversionException(message, path, value);
        }
    }
}
