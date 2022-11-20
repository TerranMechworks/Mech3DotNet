namespace Mech3DotNet.Json.Nodes
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Converters.TransformationConverter))]
    public class Transformation
    {
        public Mech3DotNet.Json.Types.Vec3 rotation;
        public Mech3DotNet.Json.Types.Vec3 translation;
        public Mech3DotNet.Json.Types.Matrix? matrix;

        public Transformation(Mech3DotNet.Json.Types.Vec3 rotation, Mech3DotNet.Json.Types.Vec3 translation, Mech3DotNet.Json.Types.Matrix? matrix)
        {
            this.rotation = rotation;
            this.translation = translation;
            this.matrix = matrix;
        }
    }
}
