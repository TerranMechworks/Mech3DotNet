using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Converters
{
    public static partial class Options
    {
        public static List<JsonConverter> GetDefaultConverters() => new List<JsonConverter>
        {
            new MotionConverterFactory(),
            new MotionFrameConverterFactory(),
            new MotionPartConverterFactory(),
        };
    }
}
