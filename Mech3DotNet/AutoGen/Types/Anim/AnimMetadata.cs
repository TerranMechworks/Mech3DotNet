using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class AnimMetadata
    {
        public Mech3DotNet.Types.Anim.AnimMission mission;
        public float gravity;
        public System.DateTime? datetime = null;
        public System.Collections.Generic.List<string> animDefNames;
        public System.Collections.Generic.List<string> scriptNames;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.AnimDefFile> animList;

        public AnimMetadata(Mech3DotNet.Types.Anim.AnimMission mission, float gravity, System.DateTime? datetime, System.Collections.Generic.List<string> animDefNames, System.Collections.Generic.List<string> scriptNames, System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.AnimDefFile> animList)
        {
            this.mission = mission;
            this.gravity = gravity;
            this.datetime = datetime;
            this.animDefNames = animDefNames;
            this.scriptNames = scriptNames;
            this.animList = animList;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<AnimMetadata> Converter = new TypeConverter<AnimMetadata>(Deserialize, Serialize);

        public static void Serialize(AnimMetadata v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("mission");
            s.Serialize(Mech3DotNet.Types.Anim.AnimMissionConverter.Converter)(v.mission);
            s.SerializeFieldName("gravity");
            ((Action<float>)s.SerializeF32)(v.gravity);
            s.SerializeFieldName("datetime");
            s.SerializeValOption(((Action<DateTime>)s.SerializeDateTime))(v.datetime);
            s.SerializeFieldName("anim_def_names");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.animDefNames);
            s.SerializeFieldName("script_names");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.scriptNames);
            s.SerializeFieldName("anim_list");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.AnimDef.AnimDefFile.Converter))(v.animList);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.AnimMission> mission;
            public Field<float> gravity;
            public Field<System.DateTime?> datetime;
            public Field<System.Collections.Generic.List<string>> animDefNames;
            public Field<System.Collections.Generic.List<string>> scriptNames;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.AnimDefFile>> animList;
        }

        public static AnimMetadata Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                mission = new Field<Mech3DotNet.Types.Anim.AnimMission>(),
                gravity = new Field<float>(),
                datetime = new Field<System.DateTime?>(null),
                animDefNames = new Field<System.Collections.Generic.List<string>>(),
                scriptNames = new Field<System.Collections.Generic.List<string>>(),
                animList = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.AnimDefFile>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "mission":
                        fields.mission.Value = d.Deserialize(Mech3DotNet.Types.Anim.AnimMissionConverter.Converter)();
                        break;
                    case "gravity":
                        fields.gravity.Value = d.DeserializeF32();
                        break;
                    case "datetime":
                        fields.datetime.Value = d.DeserializeValOption(d.DeserializeDateTime)();
                        break;
                    case "anim_def_names":
                        fields.animDefNames.Value = d.DeserializeVec(d.DeserializeString)();
                        break;
                    case "script_names":
                        fields.scriptNames.Value = d.DeserializeVec(d.DeserializeString)();
                        break;
                    case "anim_list":
                        fields.animList.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.AnimDefFile.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("AnimMetadata", fieldName);
                }
            }
            return new AnimMetadata(

                fields.mission.Unwrap("AnimMetadata", "mission"),

                fields.gravity.Unwrap("AnimMetadata", "gravity"),

                fields.datetime.Unwrap("AnimMetadata", "datetime"),

                fields.animDefNames.Unwrap("AnimMetadata", "animDefNames"),

                fields.scriptNames.Unwrap("AnimMetadata", "scriptNames"),

                fields.animList.Unwrap("AnimMetadata", "animList")

            );
        }

        #endregion
    }
}
