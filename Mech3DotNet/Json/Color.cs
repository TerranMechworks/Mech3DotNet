using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Color>))]
    public class Color
    {
        public float r;
        public float g;
        public float b;

        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public override bool Equals(object obj)
        {
            return obj is Color color &&
                   r == color.r &&
                   g == color.g &&
                   b == color.b;
        }

        public override int GetHashCode()
        {
            int hashCode = -839137856;
            hashCode = hashCode * -1521134295 + r.GetHashCode();
            hashCode = hashCode * -1521134295 + g.GetHashCode();
            hashCode = hashCode * -1521134295 + b.GetHashCode();
            return hashCode;
        }
    }
}
