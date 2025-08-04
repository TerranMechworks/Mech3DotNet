using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    public sealed class Polygon
    {
        public static readonly TypeConverter<Polygon> Converter = new TypeConverter<Polygon>(Deserialize, Serialize);
        public Mech3DotNet.Types.Gamez.Model.PolygonFlags flags;
        public int priority;
        public System.Collections.Generic.List<sbyte> zoneSet;
        public System.Collections.Generic.List<uint> vertexIndices;
        public System.Collections.Generic.List<uint>? normalIndices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Common.Color> vertexColors;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PolygonMaterial> materials;
        public uint vertexIndicesPtr;
        public uint normalIndicesPtr;
        public uint uvsPtr;
        public uint vertexColorsPtr;
        public uint matlRefsPtr;
        public uint materialsPtr;

        public Polygon(Mech3DotNet.Types.Gamez.Model.PolygonFlags flags, int priority, System.Collections.Generic.List<sbyte> zoneSet, System.Collections.Generic.List<uint> vertexIndices, System.Collections.Generic.List<uint>? normalIndices, System.Collections.Generic.List<Mech3DotNet.Types.Common.Color> vertexColors, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PolygonMaterial> materials, uint vertexIndicesPtr, uint normalIndicesPtr, uint uvsPtr, uint vertexColorsPtr, uint matlRefsPtr, uint materialsPtr)
        {
            this.flags = flags;
            this.priority = priority;
            this.zoneSet = zoneSet;
            this.vertexIndices = vertexIndices;
            this.normalIndices = normalIndices;
            this.vertexColors = vertexColors;
            this.materials = materials;
            this.vertexIndicesPtr = vertexIndicesPtr;
            this.normalIndicesPtr = normalIndicesPtr;
            this.uvsPtr = uvsPtr;
            this.vertexColorsPtr = vertexColorsPtr;
            this.matlRefsPtr = matlRefsPtr;
            this.materialsPtr = materialsPtr;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Gamez.Model.PolygonFlags> flags;
            public Field<int> priority;
            public Field<System.Collections.Generic.List<sbyte>> zoneSet;
            public Field<System.Collections.Generic.List<uint>> vertexIndices;
            public Field<System.Collections.Generic.List<uint>?> normalIndices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Color>> vertexColors;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PolygonMaterial>> materials;
            public Field<uint> vertexIndicesPtr;
            public Field<uint> normalIndicesPtr;
            public Field<uint> uvsPtr;
            public Field<uint> vertexColorsPtr;
            public Field<uint> matlRefsPtr;
            public Field<uint> materialsPtr;
        }

        public static void Serialize(Polygon v, Serializer s)
        {
            s.SerializeStruct(13);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Gamez.Model.PolygonFlagsConverter.Converter)(v.flags);
            s.SerializeFieldName("priority");
            ((Action<int>)s.SerializeI32)(v.priority);
            s.SerializeFieldName("zone_set");
            s.SerializeVec(((Action<sbyte>)s.SerializeI8))(v.zoneSet);
            s.SerializeFieldName("vertex_indices");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.vertexIndices);
            s.SerializeFieldName("normal_indices");
            s.SerializeRefOption(s.SerializeVec(((Action<uint>)s.SerializeU32)))(v.normalIndices);
            s.SerializeFieldName("vertex_colors");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter))(v.vertexColors);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Model.PolygonMaterial.Converter))(v.materials);
            s.SerializeFieldName("vertex_indices_ptr");
            ((Action<uint>)s.SerializeU32)(v.vertexIndicesPtr);
            s.SerializeFieldName("normal_indices_ptr");
            ((Action<uint>)s.SerializeU32)(v.normalIndicesPtr);
            s.SerializeFieldName("uvs_ptr");
            ((Action<uint>)s.SerializeU32)(v.uvsPtr);
            s.SerializeFieldName("vertex_colors_ptr");
            ((Action<uint>)s.SerializeU32)(v.vertexColorsPtr);
            s.SerializeFieldName("matl_refs_ptr");
            ((Action<uint>)s.SerializeU32)(v.matlRefsPtr);
            s.SerializeFieldName("materials_ptr");
            ((Action<uint>)s.SerializeU32)(v.materialsPtr);
        }

        public static Polygon Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                flags = new Field<Mech3DotNet.Types.Gamez.Model.PolygonFlags>(),
                priority = new Field<int>(),
                zoneSet = new Field<System.Collections.Generic.List<sbyte>>(),
                vertexIndices = new Field<System.Collections.Generic.List<uint>>(),
                normalIndices = new Field<System.Collections.Generic.List<uint>?>(),
                vertexColors = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Color>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PolygonMaterial>>(),
                vertexIndicesPtr = new Field<uint>(),
                normalIndicesPtr = new Field<uint>(),
                uvsPtr = new Field<uint>(),
                vertexColorsPtr = new Field<uint>(),
                matlRefsPtr = new Field<uint>(),
                materialsPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Model.PolygonFlagsConverter.Converter)();
                        break;
                    case "priority":
                        fields.priority.Value = d.DeserializeI32();
                        break;
                    case "zone_set":
                        fields.zoneSet.Value = d.DeserializeVec(d.DeserializeI8)();
                        break;
                    case "vertex_indices":
                        fields.vertexIndices.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "normal_indices":
                        fields.normalIndices.Value = d.DeserializeRefOption(d.DeserializeVec(d.DeserializeU32))();
                        break;
                    case "vertex_colors":
                        fields.vertexColors.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter))();
                        break;
                    case "materials":
                        fields.materials.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Model.PolygonMaterial.Converter))();
                        break;
                    case "vertex_indices_ptr":
                        fields.vertexIndicesPtr.Value = d.DeserializeU32();
                        break;
                    case "normal_indices_ptr":
                        fields.normalIndicesPtr.Value = d.DeserializeU32();
                        break;
                    case "uvs_ptr":
                        fields.uvsPtr.Value = d.DeserializeU32();
                        break;
                    case "vertex_colors_ptr":
                        fields.vertexColorsPtr.Value = d.DeserializeU32();
                        break;
                    case "matl_refs_ptr":
                        fields.matlRefsPtr.Value = d.DeserializeU32();
                        break;
                    case "materials_ptr":
                        fields.materialsPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Polygon", fieldName);
                }
            }
            return new Polygon(

                fields.flags.Unwrap("Polygon", "flags"),

                fields.priority.Unwrap("Polygon", "priority"),

                fields.zoneSet.Unwrap("Polygon", "zoneSet"),

                fields.vertexIndices.Unwrap("Polygon", "vertexIndices"),

                fields.normalIndices.Unwrap("Polygon", "normalIndices"),

                fields.vertexColors.Unwrap("Polygon", "vertexColors"),

                fields.materials.Unwrap("Polygon", "materials"),

                fields.vertexIndicesPtr.Unwrap("Polygon", "vertexIndicesPtr"),

                fields.normalIndicesPtr.Unwrap("Polygon", "normalIndicesPtr"),

                fields.uvsPtr.Unwrap("Polygon", "uvsPtr"),

                fields.vertexColorsPtr.Unwrap("Polygon", "vertexColorsPtr"),

                fields.matlRefsPtr.Unwrap("Polygon", "matlRefsPtr"),

                fields.materialsPtr.Unwrap("Polygon", "materialsPtr")

            );
        }
    }
}
