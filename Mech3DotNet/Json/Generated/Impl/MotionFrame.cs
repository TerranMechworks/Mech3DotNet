using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public class MotionFrame<TQuaternion, TVec3>
    {
        public TVec3 translation;
        public TQuaternion rotation;

        public MotionFrame(TVec3 translation, TQuaternion rotation)
        {
            this.translation = translation;
            this.rotation = rotation;
        }
    }
}
