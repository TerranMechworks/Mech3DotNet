using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Object3d
    {
        public static readonly TypeConverter<Object3d> Converter = new TypeConverter<Object3d>(Deserialize, Serialize);
        public float? opacity;
        public Mech3DotNet.Types.Common.Color? color;
        public float unk;
        public Mech3DotNet.Types.Gamez.Nodes.Transform transform;
        public uint signs;

        public Object3d(float? opacity, Mech3DotNet.Types.Common.Color? color, float unk, Mech3DotNet.Types.Gamez.Nodes.Transform transform, uint signs)
        {
            this.opacity = opacity;
            this.color = color;
            this.unk = unk;
            this.transform = transform;
            this.signs = signs;
        }

        private struct Fields
        {
            public Field<float?> opacity;
            public Field<Mech3DotNet.Types.Common.Color?> color;
            public Field<float> unk;
            public Field<Mech3DotNet.Types.Gamez.Nodes.Transform> transform;
            public Field<uint> signs;
        }

        public static void Serialize(Object3d v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("opacity");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.opacity);
            s.SerializeFieldName("color");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter))(v.color);
            s.SerializeFieldName("unk");
            ((Action<float>)s.SerializeF32)(v.unk);
            s.SerializeFieldName("transform");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Transform.Converter)(v.transform);
            s.SerializeFieldName("signs");
            ((Action<uint>)s.SerializeU32)(v.signs);
        }

        public static Object3d Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                opacity = new Field<float?>(),
                color = new Field<Mech3DotNet.Types.Common.Color?>(),
                unk = new Field<float>(),
                transform = new Field<Mech3DotNet.Types.Gamez.Nodes.Transform>(),
                signs = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "opacity":
                        fields.opacity.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "color":
                        fields.color.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter))();
                        break;
                    case "unk":
                        fields.unk.Value = d.DeserializeF32();
                        break;
                    case "transform":
                        fields.transform.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Transform.Converter)();
                        break;
                    case "signs":
                        fields.signs.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Object3d", fieldName);
                }
            }
            return new Object3d(

                fields.opacity.Unwrap("Object3d", "opacity"),

                fields.color.Unwrap("Object3d", "color"),

                fields.unk.Unwrap("Object3d", "unk"),

                fields.transform.Unwrap("Object3d", "transform"),

                fields.signs.Unwrap("Object3d", "signs")

            );
        }
    }
}
