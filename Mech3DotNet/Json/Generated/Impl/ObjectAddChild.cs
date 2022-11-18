namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectAddChildConverter))]
    public class ObjectAddChild
    {
        public string parent;
        public string child;

        public ObjectAddChild(string parent, string child)
        {
            this.parent = parent;
            this.child = child;
        }
    }
}
