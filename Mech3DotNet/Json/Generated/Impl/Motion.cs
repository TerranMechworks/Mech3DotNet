using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public class Motion<TQuaternion, TVec3>
    {
        public float loopTime;
        public List<MotionPart<TQuaternion, TVec3>> parts;
        public uint frameCount;

        public Motion(float loopTime, List<MotionPart<TQuaternion, TVec3>> parts, uint frameCount)
        {
            this.loopTime = loopTime;
            this.parts = parts;
            this.frameCount = frameCount;
        }
    }
}
