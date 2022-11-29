using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class AnimPtr
    {
        public static readonly TypeConverter<AnimPtr> Converter = new TypeConverter<AnimPtr>(Deserialize, Serialize);
        public string fileName;
        public uint animPtr;
        public uint animRootPtr;
        public uint objectsPtr;
        public uint nodesPtr;
        public uint lightsPtr;
        public uint puffersPtr;
        public uint dynamicSoundsPtr;
        public uint staticSoundsPtr;
        public uint activPrereqsPtr;
        public uint animRefsPtr;
        public uint resetStatePtr;
        public uint seqDefsPtr;

        public AnimPtr(string fileName, uint animPtr, uint animRootPtr, uint objectsPtr, uint nodesPtr, uint lightsPtr, uint puffersPtr, uint dynamicSoundsPtr, uint staticSoundsPtr, uint activPrereqsPtr, uint animRefsPtr, uint resetStatePtr, uint seqDefsPtr)
        {
            this.fileName = fileName;
            this.animPtr = animPtr;
            this.animRootPtr = animRootPtr;
            this.objectsPtr = objectsPtr;
            this.nodesPtr = nodesPtr;
            this.lightsPtr = lightsPtr;
            this.puffersPtr = puffersPtr;
            this.dynamicSoundsPtr = dynamicSoundsPtr;
            this.staticSoundsPtr = staticSoundsPtr;
            this.activPrereqsPtr = activPrereqsPtr;
            this.animRefsPtr = animRefsPtr;
            this.resetStatePtr = resetStatePtr;
            this.seqDefsPtr = seqDefsPtr;
        }

        private struct Fields
        {
            public Field<string> fileName;
            public Field<uint> animPtr;
            public Field<uint> animRootPtr;
            public Field<uint> objectsPtr;
            public Field<uint> nodesPtr;
            public Field<uint> lightsPtr;
            public Field<uint> puffersPtr;
            public Field<uint> dynamicSoundsPtr;
            public Field<uint> staticSoundsPtr;
            public Field<uint> activPrereqsPtr;
            public Field<uint> animRefsPtr;
            public Field<uint> resetStatePtr;
            public Field<uint> seqDefsPtr;
        }

        public static void Serialize(AnimPtr v, Serializer s)
        {
            s.SerializeStruct("AnimPtr", 13);
            s.SerializeFieldName("file_name");
            ((Action<string>)s.SerializeString)(v.fileName);
            s.SerializeFieldName("anim_ptr");
            ((Action<uint>)s.SerializeU32)(v.animPtr);
            s.SerializeFieldName("anim_root_ptr");
            ((Action<uint>)s.SerializeU32)(v.animRootPtr);
            s.SerializeFieldName("objects_ptr");
            ((Action<uint>)s.SerializeU32)(v.objectsPtr);
            s.SerializeFieldName("nodes_ptr");
            ((Action<uint>)s.SerializeU32)(v.nodesPtr);
            s.SerializeFieldName("lights_ptr");
            ((Action<uint>)s.SerializeU32)(v.lightsPtr);
            s.SerializeFieldName("puffers_ptr");
            ((Action<uint>)s.SerializeU32)(v.puffersPtr);
            s.SerializeFieldName("dynamic_sounds_ptr");
            ((Action<uint>)s.SerializeU32)(v.dynamicSoundsPtr);
            s.SerializeFieldName("static_sounds_ptr");
            ((Action<uint>)s.SerializeU32)(v.staticSoundsPtr);
            s.SerializeFieldName("activ_prereqs_ptr");
            ((Action<uint>)s.SerializeU32)(v.activPrereqsPtr);
            s.SerializeFieldName("anim_refs_ptr");
            ((Action<uint>)s.SerializeU32)(v.animRefsPtr);
            s.SerializeFieldName("reset_state_ptr");
            ((Action<uint>)s.SerializeU32)(v.resetStatePtr);
            s.SerializeFieldName("seq_defs_ptr");
            ((Action<uint>)s.SerializeU32)(v.seqDefsPtr);
        }

        public static AnimPtr Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                fileName = new Field<string>(),
                animPtr = new Field<uint>(),
                animRootPtr = new Field<uint>(),
                objectsPtr = new Field<uint>(),
                nodesPtr = new Field<uint>(),
                lightsPtr = new Field<uint>(),
                puffersPtr = new Field<uint>(),
                dynamicSoundsPtr = new Field<uint>(),
                staticSoundsPtr = new Field<uint>(),
                activPrereqsPtr = new Field<uint>(),
                animRefsPtr = new Field<uint>(),
                resetStatePtr = new Field<uint>(),
                seqDefsPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("AnimPtr"))
            {
                switch (fieldName)
                {
                    case "file_name":
                        fields.fileName.Value = d.DeserializeString();
                        break;
                    case "anim_ptr":
                        fields.animPtr.Value = d.DeserializeU32();
                        break;
                    case "anim_root_ptr":
                        fields.animRootPtr.Value = d.DeserializeU32();
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
                    case "puffers_ptr":
                        fields.puffersPtr.Value = d.DeserializeU32();
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
                    case "reset_state_ptr":
                        fields.resetStatePtr.Value = d.DeserializeU32();
                        break;
                    case "seq_defs_ptr":
                        fields.seqDefsPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("AnimPtr", fieldName);
                }
            }
            return new AnimPtr(

                fields.fileName.Unwrap("AnimPtr", "fileName"),

                fields.animPtr.Unwrap("AnimPtr", "animPtr"),

                fields.animRootPtr.Unwrap("AnimPtr", "animRootPtr"),

                fields.objectsPtr.Unwrap("AnimPtr", "objectsPtr"),

                fields.nodesPtr.Unwrap("AnimPtr", "nodesPtr"),

                fields.lightsPtr.Unwrap("AnimPtr", "lightsPtr"),

                fields.puffersPtr.Unwrap("AnimPtr", "puffersPtr"),

                fields.dynamicSoundsPtr.Unwrap("AnimPtr", "dynamicSoundsPtr"),

                fields.staticSoundsPtr.Unwrap("AnimPtr", "staticSoundsPtr"),

                fields.activPrereqsPtr.Unwrap("AnimPtr", "activPrereqsPtr"),

                fields.animRefsPtr.Unwrap("AnimPtr", "animRefsPtr"),

                fields.resetStatePtr.Unwrap("AnimPtr", "resetStatePtr"),

                fields.seqDefsPtr.Unwrap("AnimPtr", "seqDefsPtr")

            );
        }
    }
}
