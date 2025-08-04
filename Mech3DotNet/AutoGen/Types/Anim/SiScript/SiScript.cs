using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.SiScript
{
    public sealed class SiScript
    {
        public static readonly TypeConverter<SiScript> Converter = new TypeConverter<SiScript>(Deserialize, Serialize);
        public string scriptName;
        public string objectName;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.SiScript.ObjectMotionSiFrame> frames;
        public bool splineInterp;
        public uint scriptNamePtr;
        public uint objectNamePtr;
        public uint scriptDataPtr;

        public SiScript(string scriptName, string objectName, System.Collections.Generic.List<Mech3DotNet.Types.Anim.SiScript.ObjectMotionSiFrame> frames, bool splineInterp, uint scriptNamePtr, uint objectNamePtr, uint scriptDataPtr)
        {
            this.scriptName = scriptName;
            this.objectName = objectName;
            this.frames = frames;
            this.splineInterp = splineInterp;
            this.scriptNamePtr = scriptNamePtr;
            this.objectNamePtr = objectNamePtr;
            this.scriptDataPtr = scriptDataPtr;
        }

        private struct Fields
        {
            public Field<string> scriptName;
            public Field<string> objectName;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.SiScript.ObjectMotionSiFrame>> frames;
            public Field<bool> splineInterp;
            public Field<uint> scriptNamePtr;
            public Field<uint> objectNamePtr;
            public Field<uint> scriptDataPtr;
        }

        public static void Serialize(SiScript v, Serializer s)
        {
            s.SerializeStruct(7);
            s.SerializeFieldName("script_name");
            ((Action<string>)s.SerializeString)(v.scriptName);
            s.SerializeFieldName("object_name");
            ((Action<string>)s.SerializeString)(v.objectName);
            s.SerializeFieldName("frames");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.SiScript.ObjectMotionSiFrame.Converter))(v.frames);
            s.SerializeFieldName("spline_interp");
            ((Action<bool>)s.SerializeBool)(v.splineInterp);
            s.SerializeFieldName("script_name_ptr");
            ((Action<uint>)s.SerializeU32)(v.scriptNamePtr);
            s.SerializeFieldName("object_name_ptr");
            ((Action<uint>)s.SerializeU32)(v.objectNamePtr);
            s.SerializeFieldName("script_data_ptr");
            ((Action<uint>)s.SerializeU32)(v.scriptDataPtr);
        }

        public static SiScript Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                scriptName = new Field<string>(),
                objectName = new Field<string>(),
                frames = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.SiScript.ObjectMotionSiFrame>>(),
                splineInterp = new Field<bool>(),
                scriptNamePtr = new Field<uint>(),
                objectNamePtr = new Field<uint>(),
                scriptDataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "script_name":
                        fields.scriptName.Value = d.DeserializeString();
                        break;
                    case "object_name":
                        fields.objectName.Value = d.DeserializeString();
                        break;
                    case "frames":
                        fields.frames.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.SiScript.ObjectMotionSiFrame.Converter))();
                        break;
                    case "spline_interp":
                        fields.splineInterp.Value = d.DeserializeBool();
                        break;
                    case "script_name_ptr":
                        fields.scriptNamePtr.Value = d.DeserializeU32();
                        break;
                    case "object_name_ptr":
                        fields.objectNamePtr.Value = d.DeserializeU32();
                        break;
                    case "script_data_ptr":
                        fields.scriptDataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("SiScript", fieldName);
                }
            }
            return new SiScript(

                fields.scriptName.Unwrap("SiScript", "scriptName"),

                fields.objectName.Unwrap("SiScript", "objectName"),

                fields.frames.Unwrap("SiScript", "frames"),

                fields.splineInterp.Unwrap("SiScript", "splineInterp"),

                fields.scriptNamePtr.Unwrap("SiScript", "scriptNamePtr"),

                fields.objectNamePtr.Unwrap("SiScript", "objectNamePtr"),

                fields.scriptDataPtr.Unwrap("SiScript", "scriptDataPtr")

            );
        }
    }
}
