using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public enum AnimActivation
    {
        WeaponHit,
        CollideHit,
        WeaponOrCollideHit,
        OnCall,
        OnStartup,
    }

    public static class AnimActivationConverter
    {
        public static readonly TypeConverter<AnimActivation> Converter = new TypeConverter<AnimActivation>(Deserialize, Serialize);

        private static void Serialize(AnimActivation v, Serializer s)
        {
            uint variantIndex = v switch
            {
                AnimActivation.WeaponHit => 0,
                AnimActivation.CollideHit => 1,
                AnimActivation.WeaponOrCollideHit => 2,
                AnimActivation.OnCall => 3,
                AnimActivation.OnStartup => 4,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static AnimActivation Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("AnimActivation");
            return variantIndex switch
            {
                0 => AnimActivation.WeaponHit,
                1 => AnimActivation.CollideHit,
                2 => AnimActivation.WeaponOrCollideHit,
                3 => AnimActivation.OnCall,
                4 => AnimActivation.OnStartup,
                _ => throw new UnknownVariantException("AnimActivation", variantIndex),
            };
        }
    }
}
