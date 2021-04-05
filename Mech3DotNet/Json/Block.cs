using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Block>))]
    public class Block
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;

        public Block(float a, float b, float c, float d, float e, float f)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
        }
    }
}
