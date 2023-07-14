using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Cs
{
    public sealed class Light
    {
        public static readonly TypeConverter<Light> Converter = new TypeConverter<Light>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Range range;
        public uint parentPtr;
        public uint dataPtr;
        public uint nodeIndex;

        public Light(string name, Mech3DotNet.Types.Range range, uint parentPtr, uint dataPtr, uint nodeIndex)
        {
            this.name = name;
            this.range = range;
            this.parentPtr = parentPtr;
            this.dataPtr = dataPtr;
            this.nodeIndex = nodeIndex;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Range> range;
            public Field<uint> parentPtr;
            public Field<uint> dataPtr;
            public Field<uint> nodeIndex;
        }

        public static void Serialize(Light v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.RangeConverter.Converter)(v.range);
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
                range = new Field<Mech3DotNet.Types.Range>(),
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
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.RangeConverter.Converter)();
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

                fields.range.Unwrap("Light", "range"),

                fields.parentPtr.Unwrap("Light", "parentPtr"),

                fields.dataPtr.Unwrap("Light", "dataPtr"),

                fields.nodeIndex.Unwrap("Light", "nodeIndex")

            );
        }
    }
}
