using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class NodeFlags
    {
        public static readonly TypeConverter<NodeFlags> Converter = new TypeConverter<NodeFlags>(Deserialize, Serialize);
        public bool active = true;
        public bool altitudeSurface = false;
        public bool intersectSurface = false;
        public bool intersectBbox = false;
        public bool landmark = false;
        public bool unk08 = false;
        public bool hasMesh = false;
        public bool unk10 = false;
        public bool terrain = false;
        public bool canModify = false;
        public bool clipTo = false;
        public bool treeValid = true;
        public bool idZoneCheck = true;
        public bool unk25 = false;
        public bool unk28 = false;

        public NodeFlags(bool active, bool altitudeSurface, bool intersectSurface, bool intersectBbox, bool landmark, bool unk08, bool hasMesh, bool unk10, bool terrain, bool canModify, bool clipTo, bool treeValid, bool idZoneCheck, bool unk25, bool unk28)
        {
            this.active = active;
            this.altitudeSurface = altitudeSurface;
            this.intersectSurface = intersectSurface;
            this.intersectBbox = intersectBbox;
            this.landmark = landmark;
            this.unk08 = unk08;
            this.hasMesh = hasMesh;
            this.unk10 = unk10;
            this.terrain = terrain;
            this.canModify = canModify;
            this.clipTo = clipTo;
            this.treeValid = treeValid;
            this.idZoneCheck = idZoneCheck;
            this.unk25 = unk25;
            this.unk28 = unk28;
        }

        private struct Fields
        {
            public Field<bool> active;
            public Field<bool> altitudeSurface;
            public Field<bool> intersectSurface;
            public Field<bool> intersectBbox;
            public Field<bool> landmark;
            public Field<bool> unk08;
            public Field<bool> hasMesh;
            public Field<bool> unk10;
            public Field<bool> terrain;
            public Field<bool> canModify;
            public Field<bool> clipTo;
            public Field<bool> treeValid;
            public Field<bool> idZoneCheck;
            public Field<bool> unk25;
            public Field<bool> unk28;
        }

        public static void Serialize(NodeFlags v, Serializer s)
        {
            s.SerializeStruct(15);
            s.SerializeFieldName("active");
            ((Action<bool>)s.SerializeBool)(v.active);
            s.SerializeFieldName("altitude_surface");
            ((Action<bool>)s.SerializeBool)(v.altitudeSurface);
            s.SerializeFieldName("intersect_surface");
            ((Action<bool>)s.SerializeBool)(v.intersectSurface);
            s.SerializeFieldName("intersect_bbox");
            ((Action<bool>)s.SerializeBool)(v.intersectBbox);
            s.SerializeFieldName("landmark");
            ((Action<bool>)s.SerializeBool)(v.landmark);
            s.SerializeFieldName("unk08");
            ((Action<bool>)s.SerializeBool)(v.unk08);
            s.SerializeFieldName("has_mesh");
            ((Action<bool>)s.SerializeBool)(v.hasMesh);
            s.SerializeFieldName("unk10");
            ((Action<bool>)s.SerializeBool)(v.unk10);
            s.SerializeFieldName("terrain");
            ((Action<bool>)s.SerializeBool)(v.terrain);
            s.SerializeFieldName("can_modify");
            ((Action<bool>)s.SerializeBool)(v.canModify);
            s.SerializeFieldName("clip_to");
            ((Action<bool>)s.SerializeBool)(v.clipTo);
            s.SerializeFieldName("tree_valid");
            ((Action<bool>)s.SerializeBool)(v.treeValid);
            s.SerializeFieldName("id_zone_check");
            ((Action<bool>)s.SerializeBool)(v.idZoneCheck);
            s.SerializeFieldName("unk25");
            ((Action<bool>)s.SerializeBool)(v.unk25);
            s.SerializeFieldName("unk28");
            ((Action<bool>)s.SerializeBool)(v.unk28);
        }

        public static NodeFlags Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                active = new Field<bool>(true),
                altitudeSurface = new Field<bool>(false),
                intersectSurface = new Field<bool>(false),
                intersectBbox = new Field<bool>(false),
                landmark = new Field<bool>(false),
                unk08 = new Field<bool>(false),
                hasMesh = new Field<bool>(false),
                unk10 = new Field<bool>(false),
                terrain = new Field<bool>(false),
                canModify = new Field<bool>(false),
                clipTo = new Field<bool>(false),
                treeValid = new Field<bool>(true),
                idZoneCheck = new Field<bool>(true),
                unk25 = new Field<bool>(false),
                unk28 = new Field<bool>(false),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "active":
                        fields.active.Value = d.DeserializeBool();
                        break;
                    case "altitude_surface":
                        fields.altitudeSurface.Value = d.DeserializeBool();
                        break;
                    case "intersect_surface":
                        fields.intersectSurface.Value = d.DeserializeBool();
                        break;
                    case "intersect_bbox":
                        fields.intersectBbox.Value = d.DeserializeBool();
                        break;
                    case "landmark":
                        fields.landmark.Value = d.DeserializeBool();
                        break;
                    case "unk08":
                        fields.unk08.Value = d.DeserializeBool();
                        break;
                    case "has_mesh":
                        fields.hasMesh.Value = d.DeserializeBool();
                        break;
                    case "unk10":
                        fields.unk10.Value = d.DeserializeBool();
                        break;
                    case "terrain":
                        fields.terrain.Value = d.DeserializeBool();
                        break;
                    case "can_modify":
                        fields.canModify.Value = d.DeserializeBool();
                        break;
                    case "clip_to":
                        fields.clipTo.Value = d.DeserializeBool();
                        break;
                    case "tree_valid":
                        fields.treeValid.Value = d.DeserializeBool();
                        break;
                    case "id_zone_check":
                        fields.idZoneCheck.Value = d.DeserializeBool();
                        break;
                    case "unk25":
                        fields.unk25.Value = d.DeserializeBool();
                        break;
                    case "unk28":
                        fields.unk28.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("NodeFlags", fieldName);
                }
            }
            return new NodeFlags(

                fields.active.Unwrap("NodeFlags", "active"),

                fields.altitudeSurface.Unwrap("NodeFlags", "altitudeSurface"),

                fields.intersectSurface.Unwrap("NodeFlags", "intersectSurface"),

                fields.intersectBbox.Unwrap("NodeFlags", "intersectBbox"),

                fields.landmark.Unwrap("NodeFlags", "landmark"),

                fields.unk08.Unwrap("NodeFlags", "unk08"),

                fields.hasMesh.Unwrap("NodeFlags", "hasMesh"),

                fields.unk10.Unwrap("NodeFlags", "unk10"),

                fields.terrain.Unwrap("NodeFlags", "terrain"),

                fields.canModify.Unwrap("NodeFlags", "canModify"),

                fields.clipTo.Unwrap("NodeFlags", "clipTo"),

                fields.treeValid.Unwrap("NodeFlags", "treeValid"),

                fields.idZoneCheck.Unwrap("NodeFlags", "idZoneCheck"),

                fields.unk25.Unwrap("NodeFlags", "unk25"),

                fields.unk28.Unwrap("NodeFlags", "unk28")

            );
        }
    }
}
