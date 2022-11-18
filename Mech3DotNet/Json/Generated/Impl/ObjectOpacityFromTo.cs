namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectOpacityFromToConverter))]
    public class ObjectOpacityFromTo
    {
        public string node;
        public Mech3DotNet.Json.Anim.Events.ObjectOpacity opacityFrom;
        public Mech3DotNet.Json.Anim.Events.ObjectOpacity opacityTo;
        public float runtime;
        public bool fudge = false;

        public ObjectOpacityFromTo(string node, Mech3DotNet.Json.Anim.Events.ObjectOpacity opacityFrom, Mech3DotNet.Json.Anim.Events.ObjectOpacity opacityTo, float runtime, bool fudge)
        {
            this.node = node;
            this.opacityFrom = opacityFrom;
            this.opacityTo = opacityTo;
            this.runtime = runtime;
            this.fudge = fudge;
        }
    }
}
