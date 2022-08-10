using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public interface IConvertOperation
    {
        object? Convert(JsonNode? element, IEnumerable<string> path);
        Type ConvertType { get; }
    }

    public interface IConvertOperation<T>
    {
        T ConvertTo(JsonNode? element, IEnumerable<string> path);
    }
}
