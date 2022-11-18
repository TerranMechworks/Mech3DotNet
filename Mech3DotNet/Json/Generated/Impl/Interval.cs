namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.IntervalConverter))]
    public class Interval
    {
        public Mech3DotNet.Json.Anim.Events.IntervalType intervalType;
        public float intervalValue;
        public bool flag;

        public Interval(Mech3DotNet.Json.Anim.Events.IntervalType intervalType, float intervalValue, bool flag)
        {
            this.intervalType = intervalType;
            this.intervalValue = intervalValue;
            this.flag = flag;
        }
    }
}
