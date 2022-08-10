using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public class MotionPart<TQuaternion, TVec3>
    {
        public string name;
        public List<MotionFrame<TQuaternion, TVec3>> frames;

        public MotionPart(string name, List<MotionFrame<TQuaternion, TVec3>> frames)
        {
            this.name = name;
            this.frames = frames;
        }
    }
}
