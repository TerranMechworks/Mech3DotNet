using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum IfVariant
    {
        RandomWeight,
        PlayerRange,
        AnimationLod,
        HwRender,
        PlayerFirstPerson,
    }

    [JsonConverter(typeof(IfConverter))]
    public class If : IDiscriminatedUnion<IfVariant>
    {
        public If(RandomWeightCond value)
        {
            this.value = value;
            Variant = IfVariant.RandomWeight;
        }

        public If(PlayerRangeCond value)
        {
            this.value = value;
            Variant = IfVariant.PlayerRange;
        }

        public If(AnimationLodCond value)
        {
            this.value = value;
            Variant = IfVariant.AnimationLod;
        }

        public If(HwRenderCond value)
        {
            this.value = value;
            Variant = IfVariant.HwRender;
        }

        public If(PlayerFirstPersonCond value)
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
