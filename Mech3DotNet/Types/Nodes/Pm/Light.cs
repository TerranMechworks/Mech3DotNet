using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Pm
{
    public sealed class Light
    {
        public static readonly TypeConverter<Light> Converter = new TypeConverter<Light>(Deserialize, Serialize);
        public string name;
        public float unk004;
        public float unk156;
        public float unk160;
        public Mech3DotNet.Types.Types.Range range;
        public uint parentPtr;
        public uint dataPtr;
        public uint nodeIndex;

        public Light(string name, float unk004, float unk156, float unk160, Mech3DotNet.Types.Types.Range range, uint parentPtr, uint dataPtr, uint nodeIndex)
        {
            this.name = name;
            this.unk004 = unk004;
            this.unk156 = unk156;
            this.unk160 = unk160;
            this.range = range;
            this.parentPtr = parentPtr;
            this.dataPtr = dataPtr;
            this.nodeIndex = nodeIndex;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<float> unk004;
            public Field<float> unk156;
            public Field<float> unk160;
            public Field<Mech3DotNet.Types.Types.Range> range;
            public Field<uint> parentPtr;
            public Field<uint> dataPtr;
            public Field<uint> nodeIndex;
        }

        public static void Serialize(Light v, Serializer s)
        {
            s.SerializeStruct(8);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("unk004");
            ((Action<float>)s.SerializeF32)(v.unk004);
            s.SerializeFieldName("unk156");
            ((Action<float>)s.SerializeF32)(v.unk156);
            s.SerializeFieldName("unk160");
            ((Action<float>)s.SerializeF32)(v.unk160);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter)(v.range);
            s.SerializeFieldName("parent_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentPtr);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
            s.SerializeFieldName("node_index");
            ((Action<uint>)s.SerializeU32)(v.nodeIndex);
        }

        public static Light Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                unk004 = new Field<float>(),
                unk156 = new Field<float>(),
                unk160 = new Field<float>(),
                range = new Field<Mech3DotNet.Types.Types.Range>(),
                parentPtr = new Field<uint>(),
                dataPtr = new Field<uint>(),
                nodeIndex = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "unk004":
                        fields.unk004.Value = d.DeserializeF32();
                        break;
                    case "unk156":
                        fields.unk156.Value = d.DeserializeF32();
                        break;
                    case "unk160":
                        fields.unk160.Value = d.DeserializeF32();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter)();
                        break;
                    case "parent_ptr":
                        fields.parentPtr.Value = d.DeserializeU32();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    case "node_index":
                        fields.nodeIndex.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Light", fieldName);
                }
            }
            return new Light(

                fields.name.Unwrap("Light", "name"),

                fields.unk004.Unwrap("Light", "unk004"),

                fields.unk156.Unwrap("Light", "unk156"),

                fields.unk160.Unwrap("Light", "unk160"),

                fields.range.Unwrap("Light", "range"),

                fields.parentPtr.Unwrap("Light", "parentPtr"),

                fields.dataPtr.Unwrap("Light", "dataPtr"),

                fields.nodeIndex.Unwrap("Light", "nodeIndex")

            );
        }
    }
}
