using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectMotionSiFrameConverter))]
    public class ObjectMotionSiFrame
    {
        public float startTime;
        public float endTime;
        public TranslateData? translation = null;
        public RotateData? rotation = null;
        public ScaleData? scale = null;

        public ObjectMotionSiFrame(float startTime, float endTime, TranslateData? translation, RotateData? rotation, ScaleData? scale)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.translation = translation;
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}
