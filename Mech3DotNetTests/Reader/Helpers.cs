using System.Collections.Generic;
using System.Text.Json.Nodes;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNetTests.Reader
{
    public static class Helpers
    {
        public static IEnumerable<string> EmptyPath() => new List<string>() { "", "path" };

        public static TConv ConvertSuccess<TConv>(string json, IConvertOperation<TConv> op)
        {
            var element = JsonNode.Parse(json);
            return op.ConvertTo(element, EmptyPath());
        }

        public static string ConvertFailure<TConv>(string json, IConvertOperation<TConv> op)
        {
            var element = JsonNode.Parse(json);
            var e = Assert.ThrowsException<ConversionException>(() => op.ConvertTo(element, EmptyPath()));
            return e.Message;
        }
    }
}
