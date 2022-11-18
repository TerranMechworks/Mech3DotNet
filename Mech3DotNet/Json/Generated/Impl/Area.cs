namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.AreaConverter))]
    public struct Area
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public Area(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }
    }
}
