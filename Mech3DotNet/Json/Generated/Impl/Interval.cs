namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.IntervalConverter))]
    public class Interval
    {
        public IntervalType intervalType;
        public float intervalValue;
        public bool flag;

        public Interval(IntervalType intervalType, float intervalValue, bool flag)
        {
            this.intervalType = intervalType;
            this.intervalValue = intervalValue;
            this.flag = flag;
        }
    }
}
