namespace Mech3DotNet.Json.Motion
{
    public class MotionPart<TQuaternion, TVec3>
    {
        public string name;
        public System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>> frames;

        public MotionPart(string name, System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>> frames)
        {
            this.name = name;
            this.frames = frames;
        }
    }
}
