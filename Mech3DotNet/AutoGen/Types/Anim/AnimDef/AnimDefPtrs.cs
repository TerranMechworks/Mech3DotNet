using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public sealed class AnimDefPtrs
    {
        public static readonly TypeConverter<AnimDefPtrs> Converter = new TypeConverter<AnimDefPtrs>(Deserialize, Serialize);
        public uint? animHash = null;
        public uint? animRootHash = null;
        public uint seqDefsPtr;
        public uint objectsPtr;
        public uint nodesPtr;
        public uint lightsPtr;
        public uint dynamicSoundsPtr;
        public uint staticSoundsPtr;
        public uint activPrereqsPtr;
        public uint animRefsPtr;
        public uint animPtr;
        public uint animRootPtr;
        public uint puffersPtr;
        public uint effectsPtr;
        public uint resetStatePtr;

        public AnimDefPtrs(uint? animHash, uint? animRootHash, uint seqDefsPtr, uint objectsPtr, uint nodesPtr, uint lightsPtr, uint dynamicSoundsPtr, uint staticSoundsPtr, uint activPrereqsPtr, uint animRefsPtr, uint animPtr, uint animRootPtr, uint puffersPtr, uint effectsPtr, uint resetStatePtr)
        {
            this.animHash = animHash;
            this.animRootHash = animRootHash;
            this.seqDefsPtr = seqDefsPtr;
            this.objectsPtr = objectsPtr;
            this.nodesPtr = nodesPtr;
            this.lightsPtr = lightsPtr;
            this.dynamicSoundsPtr = dynamicSoundsPtr;
            this.staticSoundsPtr = staticSoundsPtr;
            this.activPrereqsPtr = activPrereqsPtr;
            this.animRefsPtr = animRefsPtr;
            this.animPtr = animPtr;
            this.animRootPtr = animRootPtr;
            this.puffersPtr = puffersPtr;
            this.effectsPtr = effectsPtr;
            this.resetStatePtr = resetStatePtr;
        }

        private struct Fields
        {
            public Field<uint?> animHash;
            public Field<uint?> animRootHash;
            public Field<uint> seqDefsPtr;
            public Field<uint> objectsPtr;
            public Field<uint> nodesPtr;
            public Field<uint> lightsPtr;
            public Field<uint> dynamicSoundsPtr;
            public Field<uint> staticSoundsPtr;
            public Field<uint> activPrereqsPtr;
            public Field<uint> animRefsPtr;
            public Field<uint> animPtr;
            public Field<uint> animRootPtr;
            public Field<uint> puffersPtr;
            public Field<uint> effectsPtr;
            public Field<uint> resetStatePtr;
        }

        public static void Serialize(AnimDefPtrs v, Serializer s)
        {
            s.SerializeStruct(15);
            s.SerializeFieldName("anim_hash");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.animHash);
            s.SerializeFieldName("anim_root_hash");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.animRootHash);
            s.SerializeFieldName("seq_defs_ptr");
            ((Action<uint>)s.SerializeU32)(v.seqDefsPtr);
            s.SerializeFieldName("objects_ptr");
            ((Action<uint>)s.SerializeU32)(v.objectsPtr);
            s.SerializeFieldName("nodes_ptr");
            ((Action<uint>)s.SerializeU32)(v.nodesPtr);
            s.SerializeFieldName("lights_ptr");
            ((Action<uint>)s.SerializeU32)(v.lightsPtr);
            s.SerializeFieldName("dynamic_sounds_ptr");
            ((Action<uint>)s.SerializeU32)(v.dynamicSoundsPtr);
            s.SerializeFieldName("static_sounds_ptr");
            ((Action<uint>)s.SerializeU32)(v.staticSoundsPtr);
            s.SerializeFieldName("activ_prereqs_ptr");
            ((Action<uint>)s.SerializeU32)(v.activPrereqsPtr);
            s.SerializeFieldName("anim_refs_ptr");
            ((Action<uint>)s.SerializeU32)(v.animRefsPtr);
            s.SerializeFieldName("anim_ptr");
            ((Action<uint>)s.SerializeU32)(v.animPtr);
            s.SerializeFieldName("anim_root_ptr");
            ((Action<uint>)s.SerializeU32)(v.animRootPtr);
            s.SerializeFieldName("puffers_ptr");
            ((Action<uint>)s.SerializeU32)(v.puffersPtr);
            s.SerializeFieldName("effects_ptr");
            ((Action<uint>)s.SerializeU32)(v.effectsPtr);
            s.SerializeFieldName("reset_state_ptr");
            ((Action<uint>)s.SerializeU32)(v.resetStatePtr);
        }

        public static AnimDefPtrs Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                animHash = new Field<uint?>(null),
                animRootHash = new Field<uint?>(null),
                seqDefsPtr = new Field<uint>(),
                objectsPtr = new Field<uint>(),
                nodesPtr = new Field<uint>(),
                lightsPtr = new Field<uint>(),
                dynamicSoundsPtr = new Field<uint>(),
                staticSoundsPtr = new Field<uint>(),
                activPrereqsPtr = new Field<uint>(),
                animRefsPtr = new Field<uint>(),
                animPtr = new Field<uint>(),
                animRootPtr = new Field<uint>(),
                puffersPtr = new Field<uint>(),
                effectsPtr = new Field<uint>(),
                resetStatePtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "anim_hash":
                        fields.animHash.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "anim_root_hash":
                        fields.animRootHash.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "seq_defs_ptr":
                        fields.seqDefsPtr.Value = d.DeserializeU32();
                        break;
                    case "objects_ptr":
                        fields.objectsPtr.Value = d.DeserializeU32();
                        break;
                    case "nodes_ptr":
                        fields.nodesPtr.Value = d.DeserializeU32();
                        break;
                    case "lights_ptr":
                        fields.lightsPtr.Value = d.DeserializeU32();
                        break;
                    case "dynamic_sounds_ptr":
                        fields.dynamicSoundsPtr.Value = d.DeserializeU32();
                        break;
                    case "static_sounds_ptr":
                        fields.staticSoundsPtr.Value = d.DeserializeU32();
                        break;
                    case "activ_prereqs_ptr":
                        fields.activPrereqsPtr.Value = d.DeserializeU32();
                        break;
                    case "anim_refs_ptr":
                        fields.animRefsPtr.Value = d.DeserializeU32();
                        break;
                    case "anim_ptr":
                        fields.animPtr.Value = d.DeserializeU32();
                        break;
                    case "anim_root_ptr":
                        fields.animRootPtr.Value = d.DeserializeU32();
                        break;
                    case "puffers_ptr":
                        fields.puffersPtr.Value = d.DeserializeU32();
                        break;
                    case "effects_ptr":
                        fields.effectsPtr.Value = d.DeserializeU32();
                        break;
                    case "reset_state_ptr":
                        fields.resetStatePtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("AnimDefPtrs", fieldName);
                }
            }
            return new AnimDefPtrs(

                fields.animHash.Unwrap("AnimDefPtrs", "animHash"),

                fields.animRootHash.Unwrap("AnimDefPtrs", "animRootHash"),

                fields.seqDefsPtr.Unwrap("AnimDefPtrs", "seqDefsPtr"),

                fields.objectsPtr.Unwrap("AnimDefPtrs", "objectsPtr"),

                fields.nodesPtr.Unwrap("AnimDefPtrs", "nodesPtr"),

                fields.lightsPtr.Unwrap("AnimDefPtrs", "lightsPtr"),

                fields.dynamicSoundsPtr.Unwrap("AnimDefPtrs", "dynamicSoundsPtr"),

                fields.staticSoundsPtr.Unwrap("AnimDefPtrs", "staticSoundsPtr"),

                fields.activPrereqsPtr.Unwrap("AnimDefPtrs", "activPrereqsPtr"),

                fields.animRefsPtr.Unwrap("AnimDefPtrs", "animRefsPtr"),

                fields.animPtr.Unwrap("AnimDefPtrs", "animPtr"),

                fields.animRootPtr.Unwrap("AnimDefPtrs", "animRootPtr"),

                fields.puffersPtr.Unwrap("AnimDefPtrs", "puffersPtr"),

                fields.effectsPtr.Unwrap("AnimDefPtrs", "effectsPtr"),

                fields.resetStatePtr.Unwrap("AnimDefPtrs", "resetStatePtr")

            );
        }
    }
}
