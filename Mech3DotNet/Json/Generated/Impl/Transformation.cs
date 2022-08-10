using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TransformationConverter))]
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
