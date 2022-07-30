using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Matrix>))]
    public class Matrix
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
        public float g;
        public float h;
        public float i;

        public Matrix(float a, float b, float c, float d, float e, float f, float g, float h, float i)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
        }
    }
}
