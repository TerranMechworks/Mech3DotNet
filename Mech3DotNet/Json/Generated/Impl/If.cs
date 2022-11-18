namespace Mech3DotNet.Json.Anim.Events
{
    public enum IfVariant
    {
        RandomWeight,
        PlayerRange,
        AnimationLod,
        HwRender,
        PlayerFirstPerson,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.IfConverter))]
    public class If : Mech3DotNet.Json.Converters.IDiscriminatedUnion<IfVariant>
    {
        public If(Mech3DotNet.Json.Anim.Events.RandomWeightCond value)
        {
            this.value = value;
            Variant = IfVariant.RandomWeight;
        }

        public If(Mech3DotNet.Json.Anim.Events.PlayerRangeCond value)
        {
            this.value = value;
            Variant = IfVariant.PlayerRange;
        }

        public If(Mech3DotNet.Json.Anim.Events.AnimationLodCond value)
        {
            this.value = value;
            Variant = IfVariant.AnimationLod;
        }

        public If(Mech3DotNet.Json.Anim.Events.HwRenderCond value)
        {
            this.value = value;
            Variant = IfVariant.HwRender;
        }

        public If(Mech3DotNet.Json.Anim.Events.PlayerFirstPersonCond value)
        {
            this.value = value;
            Variant = IfVariant.PlayerFirstPerson;
        }

        protected object value;
        public IfVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
