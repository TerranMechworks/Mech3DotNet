namespace Mech3DotNet.Json
{
    public class Motion<TQuaternion, TVec3>
    {
        public float loopTime;
        public System.Collections.Generic.List<MotionPart<TQuaternion, TVec3>> parts;
        public uint frameCount;

        public Motion(float loopTime, System.Collections.Generic.List<MotionPart<TQuaternion, TVec3>> parts, uint frameCount)
        {
            this.loopTime = loopTime;
            this.parts = parts;
            this.frameCount = frameCount;
        }
    }
}
