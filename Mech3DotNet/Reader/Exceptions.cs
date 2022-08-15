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
        protected static string AddNode(string message, IEnumerable<string> path, JsonNode node)
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            var displayJson = node.ToJsonString(options);
            var displayPath = string.Join("/", path);
            return $"{message}. Path '{displayPath}'. Json: {displayJson}";
        }

        public ConversionException(string message, IEnumerable<string> path, JsonNode node) : base(AddNode(message, path, node)) { }
        public ConversionException(string message, IEnumerable<string> path) : base(message, path) { }

        public static JsonNode NotNull(JsonNode? node, IEnumerable<string> path)
        {
            if (node is null)
                throw new ConversionException("Value is null", path);
            return node;
        }

        public static JsonArray Array(JsonNode? node, IEnumerable<string> path)
        {
            if (node is null)
                throw new ConversionException("Value is null", path);
            if (node is JsonArray array)
                return array;
            throw new ConversionException("Value is not an array", path, node);
        }

        public static JsonValue Scalar(JsonNode? node, IEnumerable<string> path)
        {
            if (node is null)
                throw new ConversionException("Value is null", path);
            if (node is JsonValue direct_value)
                return direct_value;
            // it is common for reader data to contain scalar values as a
            // single value in an array. this would be tedious to unpack each
            // time, so this function attempts to unpack such array. this
            // should technically modify the path, but is only used by leaf
            // converters like `ToInt`, where the path is irrelevant since
            // there cannot be further queries/conversions.
            if (node is JsonArray array && array.Count == 1)
            {
                var only = array[0];
                if (only != null && only is JsonValue nested_value)
                    return nested_value;
            }
            throw new ConversionException("Value is not a scalar", path, node);
        }
    }

    // public class UnknownTypeException : ConversionException
    // {
    //     public UnknownTypeException(string message) : base(message) { }
    // }

    // public class NoConstructorException : ConversionException
    // {
    //     public NoConstructorException(string message) : base(message) { }
    // }

    // public class UnknownFieldException : ConversionException
    // {
    //     public UnknownFieldException(string message) : base(message) { }
    // }

    // public class RequiredFieldsException : ConversionException
    // {
    //     public RequiredFieldsException(string message) : base(message) { }
    // }
}
