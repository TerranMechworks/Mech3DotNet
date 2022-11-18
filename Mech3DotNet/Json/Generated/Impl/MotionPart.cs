namespace Mech3DotNet.Json
{
    public class MotionPart<TQuaternion, TVec3>
    {
        public string name;
        public System.Collections.Generic.List<MotionFrame<TQuaternion, TVec3>> frames;

        public MotionPart(string name, System.Collections.Generic.List<MotionFrame<TQuaternion, TVec3>> frames)
        {
            this.name = name;
            this.frames = frames;
        }
    }
}
