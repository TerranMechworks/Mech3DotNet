using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class AnimMetadata
    {
        public static readonly TypeConverter<AnimMetadata> Converter = new TypeConverter<AnimMetadata>(Deserialize, Serialize);
        public uint basePtr;
        public uint worldPtr;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimName> animNames;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimPtr> animPtrs;

        public AnimMetadata(uint basePtr, uint worldPtr, System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimName> animNames, System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimPtr> animPtrs)
        {
            this.basePtr = basePtr;
            this.worldPtr = worldPtr;
            this.animNames = animNames;
            this.animPtrs = animPtrs;
        }

        private struct Fields
        {
            public Field<uint> basePtr;
            public Field<uint> worldPtr;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimName>> animNames;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimPtr>> animPtrs;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.AnimMetadata v, Serializer s)
        {
            s.SerializeStruct("AnimMetadata", 4);
            s.SerializeFieldName("base_ptr");
            ((Action<uint>)s.SerializeU32)(v.basePtr);
            s.SerializeFieldName("world_ptr");
            ((Action<uint>)s.SerializeU32)(v.worldPtr);
            s.SerializeFieldName("anim_names");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.AnimName.Converter))(v.animNames);
            s.SerializeFieldName("anim_ptrs");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.AnimPtr.Converter))(v.animPtrs);
        }

        public static Mech3DotNet.Types.Anim.AnimMetadata Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                basePtr = new Field<uint>(),
                worldPtr = new Field<uint>(),
                animNames = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimName>>(),
                animPtrs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimPtr>>(),
            };
            foreach (var fieldName in d.DeserializeStruct("AnimMetadata"))
            {
                switch (fieldName)
                {
                    case "base_ptr":
                        fields.basePtr.Value = d.DeserializeU32();
                        break;
                    case "world_ptr":
                        fields.worldPtr.Value = d.DeserializeU32();
                        break;
                    case "anim_names":
                        fields.animNames.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.AnimName.Converter))();
                        break;
                    case "anim_ptrs":
                        fields.animPtrs.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.AnimPtr.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("AnimMetadata", fieldName);
                }
            }
            return new AnimMetadata(

                fields.basePtr.Unwrap("AnimMetadata", "basePtr"),

                fields.worldPtr.Unwrap("AnimMetadata", "worldPtr"),

                fields.animNames.Unwrap("AnimMetadata", "animNames"),

                fields.animPtrs.Unwrap("AnimMetadata", "animPtrs")

            );
        }
    }
}
