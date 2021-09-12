using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static Mech3DotNet.Reader.Helpers;

namespace Mech3DotNet.Reader
{
    public class ReaderException : Exception
    {
        public ReaderException() : base() { }

        public ReaderException(string message) : base(message) { }
    }

    public class InvalidRootException : ReaderException { }

    public class NotFoundException : ReaderException
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class InvalidTypeException : ReaderException
    {
        private InvalidTypeException(string message) : base(message) { }

        public static void Assert(JToken token, JTokenType expected, IEnumerable<string> path)
        {
            var actual = token.Type;
            if (expected != actual)
                throw new InvalidTypeException(AddPath($"Expected '{expected}', but was '{actual}' ({token})", path));
        }

        public static JArray Array(JToken token, IEnumerable<string> path)
        {
            InvalidTypeException.Assert(token, JTokenType.Array, path);
            return (JArray)token;
        }

        public static string String(JToken token, IEnumerable<string> path)
        {
            InvalidTypeException.Assert(token, JTokenType.String, path);
            return (string)token;
        }
    }

    public class ConversionException : ReaderException
    {
        public ConversionException() : base() { }

        public ConversionException(string message) : base(message) { }
    }

    public class UnknownTypeException : ConversionException
    {
        public UnknownTypeException(string message) : base(message) { }
    }

    public class NoConstructorException : ConversionException
    {
        public NoConstructorException(string message) : base(message) { }
    }

    public class UnknownFieldException : ConversionException
    {
        public UnknownFieldException(string message) : base(message) { }
    }

    public class RequiredFieldsException : ConversionException
    {
        public RequiredFieldsException(string message) : base(message) { }
    }
}
