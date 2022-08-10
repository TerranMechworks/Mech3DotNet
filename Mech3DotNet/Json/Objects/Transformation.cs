using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class Transformation
    {
        [JsonProperty("rotation", Required = Required.Always)]
        public Vec3 rotation;
        [JsonProperty("translation", Required = Required.Always)]
        public Vec3 translation;
        [JsonProperty("matrix", Required = Required.AllowNull)]
        public Matrix? matrix;

        public Transformation(Vec3 rotation, Vec3 translation, Matrix? matrix)
        {
            this.rotation = rotation;
            this.translation = translation;
            this.matrix = matrix;
        }

        [JsonConstructor]
        private Transformation() { }
    }
}
