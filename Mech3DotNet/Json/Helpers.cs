using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    internal static class Helpers
    {
        internal static string AddPath(JsonReader reader, string path, string message)
        {
            message += $". Path '{path}'";
            var lineInfo = reader as IJsonLineInfo;
            if (lineInfo != null && lineInfo.HasLineInfo())
                message += $", line {lineInfo.LineNumber}, position {lineInfo.LinePosition}";
            message += ".";
            return message;
        }

        internal static string AddPath(JsonReader reader, string message)
        {
            return AddPath(reader, reader.Path, message);
        }
    }
}
