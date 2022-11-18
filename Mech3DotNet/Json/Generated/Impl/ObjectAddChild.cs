namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectAddChildConverter))]
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
