using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public interface IConvertOperation<T>
    {
        T ConvertTo(JsonNode? node, IEnumerable<string> path);
    }
}
