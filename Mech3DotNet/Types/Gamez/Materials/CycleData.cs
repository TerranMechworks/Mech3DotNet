using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public sealed class CycleData
    {
        public static readonly TypeConverter<CycleData> Converter = new TypeConverter<CycleData>(Deserialize, Serialize);
        public System.Collections.Generic.List<string> textures;
        public bool unk00;
        public uint unk04;
        public float unk12;
        public uint infoPtr;
        public uint dataPtr;

        public CycleData(System.Collections.Generic.List<string> textures, bool unk00, uint unk04, float unk12, uint infoPtr, uint dataPtr)
        {
            this.textures = textures;
            this.unk00 = unk00;
            this.unk04 = unk04;
            this.unk12 = unk12;
            this.infoPtr = infoPtr;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<string>> textures;
            public Field<bool> unk00;
            public Field<uint> unk04;
            public Field<float> unk12;
            public Field<uint> infoPtr;
            public Field<uint> dataPtr;
        }

        public static void Serialize(CycleData v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("textures");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.textures);
            s.SerializeFieldName("unk00");
            ((Action<bool>)s.SerializeBool)(v.unk00);
            s.SerializeFieldName("unk04");
            ((Action<uint>)s.SerializeU32)(v.unk04);
            s.SerializeFieldName("unk12");
            ((Action<float>)s.SerializeF32)(v.unk12);
            s.SerializeFieldName("info_ptr");
            ((Action<uint>)s.SerializeU32)(v.infoPtr);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
        }

        public static CycleData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<string>>(),
                unk00 = new Field<bool>(),
                unk04 = new Field<uint>(),
                unk12 = new Field<float>(),
                infoPtr = new Field<uint>(),
                dataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "textures":
                        fields.textures.Value = d.DeserializeVec(d.DeserializeString)();
                        break;
                    case "unk00":
                        fields.unk00.Value = d.DeserializeBool();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeU32();
                        break;
                    case "unk12":
                        fields.unk12.Value = d.DeserializeF32();
                        break;
                    case "info_ptr":
                        fields.infoPtr.Value = d.DeserializeU32();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("CycleData", fieldName);
                }
            }
            return new CycleData(

                fields.textures.Unwrap("CycleData", "textures"),

                fields.unk00.Unwrap("CycleData", "unk00"),

                fields.unk04.Unwrap("CycleData", "unk04"),

                fields.unk12.Unwrap("CycleData", "unk12"),

                fields.infoPtr.Unwrap("CycleData", "infoPtr"),

                fields.dataPtr.Unwrap("CycleData", "dataPtr")

            );
        }
    }
}
