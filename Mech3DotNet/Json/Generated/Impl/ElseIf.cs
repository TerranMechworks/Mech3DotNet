namespace Mech3DotNet.Json.Anim.Events
{
    public enum ElseIfVariant
    {
        RandomWeight,
        PlayerRange,
        AnimationLod,
        HwRender,
        PlayerFirstPerson,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ElseIfConverter))]
    public class ElseIf : Mech3DotNet.Json.Converters.IDiscriminatedUnion<ElseIfVariant>
    {
        public ElseIf(Mech3DotNet.Json.Anim.Events.RandomWeightCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.RandomWeight;
        }

        public ElseIf(Mech3DotNet.Json.Anim.Events.PlayerRangeCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.PlayerRange;
        }

        public ElseIf(Mech3DotNet.Json.Anim.Events.AnimationLodCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.AnimationLod;
        }

        public ElseIf(Mech3DotNet.Json.Anim.Events.HwRenderCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.HwRender;
        }

        public ElseIf(Mech3DotNet.Json.Anim.Events.PlayerFirstPersonCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.PlayerFirstPerson;
        }

        protected object value;
        public ElseIfVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
