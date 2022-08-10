using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Converters
{
    public static partial class Options
    {
        public static JsonSerializerOptions GlobalOptions = GetOptions(GetDefaultConverters());

        public static JsonSerializerOptions GetOptions(IEnumerable<JsonConverter> converters)
        {
            var options = new JsonSerializerOptions { };
            // AllowTrailingCommas = false,
            // DefaultBufferSize = 16384,
            // DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            // DictionaryKeyPolicy = null,
            // Encoder = null,
            // IgnoreReadOnlyFields = false,
            // IgnoreReadOnlyProperties = false,
            // IncludeFields = false,
            // MaxDepth = 0, // means 64
            // NumberHandling = JsonNumberHandling.Strict, // unclear default
            // PropertyNameCaseInsensitive = false,
            // PropertyNamingPolicy = null,
            // ReadCommentHandling = JsonCommentHandling.Disallow,
            // ReferenceHandler = null,
            // UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
            // UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode,
            // WriteIndented = false,
            foreach (var converter in converters)
                options.Converters.Add(converter);
            return options;
        }
    }
}
