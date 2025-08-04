using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FbfxCsinwaveFromTo
    {
        public static readonly TypeConverter<FbfxCsinwaveFromTo> Converter = new TypeConverter<FbfxCsinwaveFromTo>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.AtNode? atNode;
        public Mech3DotNet.Types.Anim.Events.FbfxCsinwaveScreenPos? screenPos;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? worldRadius;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? screenRadius;
        public Mech3DotNet.Types.Anim.Events.FbfxCsinwaveCsin csin;
        public float runTime;

        public FbfxCsinwaveFromTo(Mech3DotNet.Types.Anim.Events.AtNode? atNode, Mech3DotNet.Types.Anim.Events.FbfxCsinwaveScreenPos? screenPos, Mech3DotNet.Types.Anim.Events.FloatFromTo? worldRadius, Mech3DotNet.Types.Anim.Events.FloatFromTo? screenRadius, Mech3DotNet.Types.Anim.Events.FbfxCsinwaveCsin csin, float runTime)
        {
            this.atNode = atNode;
            this.screenPos = screenPos;
            this.worldRadius = worldRadius;
            this.screenRadius = screenRadius;
            this.csin = csin;
            this.runTime = runTime;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.AtNode?> atNode;
            public Field<Mech3DotNet.Types.Anim.Events.FbfxCsinwaveScreenPos?> screenPos;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> worldRadius;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> screenRadius;
            public Field<Mech3DotNet.Types.Anim.Events.FbfxCsinwaveCsin> csin;
            public Field<float> runTime;
        }

        public static void Serialize(FbfxCsinwaveFromTo v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("at_node");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))(v.atNode);
            s.SerializeFieldName("screen_pos");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FbfxCsinwaveScreenPos.Converter))(v.screenPos);
            s.SerializeFieldName("world_radius");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.worldRadius);
            s.SerializeFieldName("screen_radius");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.screenRadius);
            s.SerializeFieldName("csin");
            s.Serialize(Mech3DotNet.Types.Anim.Events.FbfxCsinwaveCsin.Converter)(v.csin);
            s.SerializeFieldName("run_time");
            ((Action<float>)s.SerializeF32)(v.runTime);
        }

        public static FbfxCsinwaveFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                atNode = new Field<Mech3DotNet.Types.Anim.Events.AtNode?>(),
                screenPos = new Field<Mech3DotNet.Types.Anim.Events.FbfxCsinwaveScreenPos?>(),
                worldRadius = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                screenRadius = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                csin = new Field<Mech3DotNet.Types.Anim.Events.FbfxCsinwaveCsin>(),
                runTime = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "at_node":
                        fields.atNode.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))();
                        break;
                    case "screen_pos":
                        fields.screenPos.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FbfxCsinwaveScreenPos.Converter))();
                        break;
                    case "world_radius":
                        fields.worldRadius.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "screen_radius":
                        fields.screenRadius.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "csin":
                        fields.csin.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.FbfxCsinwaveCsin.Converter)();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("FbfxCsinwaveFromTo", fieldName);
                }
            }
            return new FbfxCsinwaveFromTo(

                fields.atNode.Unwrap("FbfxCsinwaveFromTo", "atNode"),

                fields.screenPos.Unwrap("FbfxCsinwaveFromTo", "screenPos"),

                fields.worldRadius.Unwrap("FbfxCsinwaveFromTo", "worldRadius"),

                fields.screenRadius.Unwrap("FbfxCsinwaveFromTo", "screenRadius"),

                fields.csin.Unwrap("FbfxCsinwaveFromTo", "csin"),

                fields.runTime.Unwrap("FbfxCsinwaveFromTo", "runTime")

            );
        }
    }
}
