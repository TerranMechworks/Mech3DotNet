namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.LoopConverter))]
    public class Loop
    {
        public int start;
        public int loopCount;

        public Loop(int start, int loopCount)
        {
            this.start = start;
            this.loopCount = loopCount;
        }
    }
}
