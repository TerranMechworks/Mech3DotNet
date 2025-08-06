using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public sealed class CycleData
    {
        public System.Collections.Generic.List<short> textureIndices;
        public bool looping;
        public float speed;
        public int currentFrame;
        public uint cyclePtr;
        public uint texMapPtr;

        public CycleData(System.Collections.Generic.List<short> textureIndices, bool looping, float speed, int currentFrame, uint cyclePtr, uint texMapPtr)
        {
            this.textureIndices = textureIndices;
            this.looping = looping;
            this.speed = speed;
            this.currentFrame = currentFrame;
            this.cyclePtr = cyclePtr;
            this.texMapPtr = texMapPtr;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<CycleData> Converter = new TypeConverter<CycleData>(Deserialize, Serialize);

        public static void Serialize(CycleData v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("texture_indices");
            s.SerializeVec(((Action<short>)s.SerializeI16))(v.textureIndices);
            s.SerializeFieldName("looping");
            ((Action<bool>)s.SerializeBool)(v.looping);
            s.SerializeFieldName("speed");
            ((Action<float>)s.SerializeF32)(v.speed);
            s.SerializeFieldName("current_frame");
            ((Action<int>)s.SerializeI32)(v.currentFrame);
            s.SerializeFieldName("cycle_ptr");
            ((Action<uint>)s.SerializeU32)(v.cyclePtr);
            s.SerializeFieldName("tex_map_ptr");
            ((Action<uint>)s.SerializeU32)(v.texMapPtr);
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<short>> textureIndices;
            public Field<bool> looping;
            public Field<float> speed;
            public Field<int> currentFrame;
            public Field<uint> cyclePtr;
            public Field<uint> texMapPtr;
        }

        public static CycleData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textureIndices = new Field<System.Collections.Generic.List<short>>(),
                looping = new Field<bool>(),
                speed = new Field<float>(),
                currentFrame = new Field<int>(),
                cyclePtr = new Field<uint>(),
                texMapPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "texture_indices":
                        fields.textureIndices.Value = d.DeserializeVec(d.DeserializeI16)();
                        break;
                    case "looping":
                        fields.looping.Value = d.DeserializeBool();
                        break;
                    case "speed":
                        fields.speed.Value = d.DeserializeF32();
                        break;
                    case "current_frame":
                        fields.currentFrame.Value = d.DeserializeI32();
                        break;
                    case "cycle_ptr":
                        fields.cyclePtr.Value = d.DeserializeU32();
                        break;
                    case "tex_map_ptr":
                        fields.texMapPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("CycleData", fieldName);
                }
            }
            return new CycleData(

                fields.textureIndices.Unwrap("CycleData", "textureIndices"),

                fields.looping.Unwrap("CycleData", "looping"),

                fields.speed.Unwrap("CycleData", "speed"),

                fields.currentFrame.Unwrap("CycleData", "currentFrame"),

                fields.cyclePtr.Unwrap("CycleData", "cyclePtr"),

                fields.texMapPtr.Unwrap("CycleData", "texMapPtr")

            );
        }

        #endregion
    }
}
