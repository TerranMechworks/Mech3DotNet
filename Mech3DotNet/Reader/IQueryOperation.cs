using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public interface IQueryOperation
    {
        JsonNode? Apply(JsonNode? node, List<string> path);
    }
}
