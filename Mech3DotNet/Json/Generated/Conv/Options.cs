using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Converters
{
    public static partial class Options
    {
        public static List<JsonConverter> GetDefaultConverters() => new List<JsonConverter>
        {
            new Mech3DotNet.Json.Motion.Converters.MotionConverterFactory(),
            new Mech3DotNet.Json.Motion.Converters.MotionFrameConverterFactory(),
            new Mech3DotNet.Json.Motion.Converters.MotionPartConverterFactory(),
        };
    }
}
