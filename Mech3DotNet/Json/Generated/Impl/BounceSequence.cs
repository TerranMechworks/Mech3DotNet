namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.BounceSequenceConverter))]
    public class BounceSequence
    {
        public string? seqName0;
        public string? seqName1;
        public string? seqName2;

        public BounceSequence(string? seqName0, string? seqName1, string? seqName2)
        {
            this.seqName0 = seqName0;
            this.seqName1 = seqName1;
            this.seqName2 = seqName2;
        }
    }
}
