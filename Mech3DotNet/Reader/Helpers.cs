using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Mech3DotNet.Reader
{
    internal static class Helpers
    {
        internal static string AddPath(string message, IEnumerable<string> path)
        {
            var displayPath = string.Join("/", path);
            return $"{message}. Path '{displayPath}'.";
        }

        internal static List<string> ExtendPath(IEnumerable<string> oldPath, string component)
        {
            var newPath = new List<string>(oldPath);
            newPath.Add(component);
            return newPath;
        }

        internal static JToken UnpackSingleValueFromArray(JToken token, JTokenType type, IEnumerable<string> path)
        {
            if (token.Type == type)
                return token;
            var array = InvalidTypeException.Array(token, path);
            if (array.Count != 1)
                throw new ConversionException(AddPath($"Expected one item, but found {array.Count} ({array})", path));
            var first = array.First;
            InvalidTypeException.Assert(first, type, path);
            return first;
        }
    }
}
