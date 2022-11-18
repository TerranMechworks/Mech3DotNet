namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectOpacityFromToConverter))]
    public class ObjectOpacityFromTo
    {
        public string node;
        public ObjectOpacity opacityFrom;
        public ObjectOpacity opacityTo;
        public float runtime;
        public bool fudge = false;

        public ObjectOpacityFromTo(string node, ObjectOpacity opacityFrom, ObjectOpacity opacityTo, float runtime, bool fudge)
        {
            this.node = node;
            this.opacityFrom = opacityFrom;
            this.opacityTo = opacityTo;
            this.runtime = runtime;
            this.fudge = fudge;
        }
    }
}
