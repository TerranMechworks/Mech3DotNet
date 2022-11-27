using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public struct Area
    {
        public static readonly TypeConverter<Area> Converter = new TypeConverter<Area>(Deserialize, Serialize);
        public int left;
        public int top;
        public int right;
        public int bottom;

        public Area(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        private struct Fields
        {
            public Field<int> left;
            public Field<int> top;
            public Field<int> right;
            public Field<int> bottom;
        }

        public static void Serialize(Mech3DotNet.Types.Nodes.Area v, Serializer s)
        {
            s.SerializeStruct("Area", 4);
            s.SerializeFieldName("left");
            ((Action<int>)s.SerializeI32)(v.left);
            s.SerializeFieldName("top");
            ((Action<int>)s.SerializeI32)(v.top);
            s.SerializeFieldName("right");
            ((Action<int>)s.SerializeI32)(v.right);
            s.SerializeFieldName("bottom");
            ((Action<int>)s.SerializeI32)(v.bottom);
        }

        public static Mech3DotNet.Types.Nodes.Area Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                left = new Field<int>(),
                top = new Field<int>(),
                right = new Field<int>(),
                bottom = new Field<int>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Area"))
            {
                switch (fieldName)
                {
                    case "left":
                        fields.left.Value = d.DeserializeI32();
                        break;
                    case "top":
                        fields.top.Value = d.DeserializeI32();
                        break;
                    case "right":
                        fields.right.Value = d.DeserializeI32();
                        break;
                    case "bottom":
                        fields.bottom.Value = d.DeserializeI32();
                        break;
                    default:
                        throw new UnknownFieldException("Area", fieldName);
                }
            }
            return new Area(

                fields.left.Unwrap("Area", "left"),

                fields.top.Unwrap("Area", "top"),

                fields.right.Unwrap("Area", "right"),

                fields.bottom.Unwrap("Area", "bottom")

            );
        }
    }
}
