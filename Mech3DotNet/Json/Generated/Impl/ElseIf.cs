using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum ElseIfVariant
    {
        RandomWeight,
        PlayerRange,
        AnimationLod,
        HwRender,
        PlayerFirstPerson,
    }

    [JsonConverter(typeof(ElseIfConverter))]
    public class ElseIf : IDiscriminatedUnion<ElseIfVariant>
    {
        public ElseIf(RandomWeightCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.RandomWeight;
        }

        public ElseIf(PlayerRangeCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.PlayerRange;
        }

        public ElseIf(AnimationLodCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.AnimationLod;
        }

        public ElseIf(HwRenderCond value)
        {
            this.value = value;
            Variant = ElseIfVariant.HwRender;
        }

        public ElseIf(PlayerFirstPersonCond value)
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
