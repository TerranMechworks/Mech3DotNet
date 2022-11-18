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
