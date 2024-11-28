using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Archive
{
    public sealed class ArchiveEntryInfo
    {
        public static readonly TypeConverter<ArchiveEntryInfo> Converter = new TypeConverter<ArchiveEntryInfo>(Deserialize, Serialize);

        public enum Variants
        {
            Valid,
            Invalid,
        }

        private ArchiveEntryInfo(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static ArchiveEntryInfo Valid(Mech3DotNet.Types.Archive.ArchiveEntryInfoValid value) => new ArchiveEntryInfo(Variants.Valid, value);

        public static ArchiveEntryInfo Invalid(Mech3DotNet.Types.Archive.ArchiveEntryInfoInvalid value) => new ArchiveEntryInfo(Variants.Invalid, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsValid() => Variant == Variants.Valid;
        public Mech3DotNet.Types.Archive.ArchiveEntryInfoValid AsValid() => (Mech3DotNet.Types.Archive.ArchiveEntryInfoValid)Value;
        public bool IsInvalid() => Variant == Variants.Invalid;
        public Mech3DotNet.Types.Archive.ArchiveEntryInfoInvalid AsInvalid() => (Mech3DotNet.Types.Archive.ArchiveEntryInfoInvalid)Value;

        private static void Serialize(ArchiveEntryInfo v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Valid: // 0
                    {
                        var inner = v.AsValid();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Archive.ArchiveEntryInfoValid.Converter)(inner);
                        break;
                    }

                case Variants.Invalid: // 1
                    {
                        var inner = v.AsInvalid();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Archive.ArchiveEntryInfoInvalid.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static ArchiveEntryInfo Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Valid
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ArchiveEntryInfo", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Archive.ArchiveEntryInfoValid.Converter)();
                        return ArchiveEntryInfo.Valid(inner);
                    }

                case 1: // Invalid
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ArchiveEntryInfo", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Archive.ArchiveEntryInfoInvalid.Converter)();
                        return ArchiveEntryInfo.Invalid(inner);
                    }

                default:
                    throw new UnknownVariantException("ArchiveEntryInfo", variantIndex);
            }
        }
    }
}
