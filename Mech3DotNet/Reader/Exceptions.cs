using System;
using System.Collections.Generic;
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
    }

    public class NotFoundException : ReaderException
    {
        public NotFoundException(string message, IEnumerable<string> path) : base(message, path) { }
    }

    public class NotAnArrayException : ReaderException
    {
        public NotAnArrayException(string message, IEnumerable<string> path) : base(message, path) { }

        public static JsonArray Cast(JsonNode? element, IEnumerable<string> path)
        {
            if (element is null)
                throw new NotAnArrayException("Element is null", path);
            var array = element as JsonArray;
            if (array is null)
                throw new NotAnArrayException($"Element is not an array ({element.GetType().FullName})", path);
            return array;
        }
    }

    public class ConversionException : ReaderException
    {
        public ConversionException(string message, IEnumerable<string> path) : base(message, path) { }
    }

    // public class InvalidTypeException : ReaderException
    // {
    //     public InvalidTypeException(string message) : base(message) { }

    //     public static void Assert(JToken token, JTokenType expected, IEnumerable<string> path)
    //     {
    //         var actual = token.Type;
    //         if (expected != actual)
    //             throw new InvalidTypeException(AddPath($"Expected '{expected}', but was '{actual}' ({token})", path));
    //     }

    //     public static JArray Array(JToken token, IEnumerable<string> path)
    //     {
    //         InvalidTypeException.Assert(token, JTokenType.Array, path);
    //         return (JArray)token;
    //     }

    //     public static string String(JToken token, IEnumerable<string> path)
    //     {
    //         InvalidTypeException.Assert(token, JTokenType.String, path);
    //         return (string)token;
    //     }
    // }

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
