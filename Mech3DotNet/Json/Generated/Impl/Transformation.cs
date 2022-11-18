namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TransformationConverter))]
    public class Transformation
    {
        public Vec3 rotation;
        public Vec3 translation;
        public Matrix? matrix;

        public Transformation(Vec3 rotation, Vec3 translation, Matrix? matrix)
        {
            this.rotation = rotation;
            this.translation = translation;
            this.matrix = matrix;
        }
    }
}
