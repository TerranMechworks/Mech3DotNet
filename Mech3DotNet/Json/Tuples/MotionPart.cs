using System;
using System.Collections.Generic;

namespace Mech3DotNet.Json
{
    public class MotionPart<V3, V4>
    {
        public string name;
        public List<MotionFrame<V3, V4>> frames;

        public MotionPart(string name, List<MotionFrame<V3, V4>> frames)
        {
            this.name = name;
            this.frames = frames;
        }
    }

    public class MotionPartConverter<V3, V4> : TupleConverter<MotionPart<V3, V4>> { }
}
