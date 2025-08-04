using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class ObjectRef
    {
        public static readonly TypeConverter<ObjectRef> Converter = new TypeConverter<ObjectRef>(Deserialize, Serialize);
        public string name;
        public uint? ptr = null;
        public uint flags;
        public uint? flagsMerged = null;
        public byte[] affine;

        public ObjectRef(string name, uint? ptr, uint flags, uint? flagsMerged, byte[] affine)
        {
            this.name = name;
            this.ptr = ptr;
            this.flags = flags;
            this.flagsMerged = flagsMerged;
            this.affine = affine;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<uint?> ptr;
            public Field<uint> flags;
            public Field<uint?> flagsMerged;
            public Field<byte[]> affine;
        }

        public static void Serialize(ObjectRef v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("ptr");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.ptr);
            s.SerializeFieldName("flags");
            ((Action<uint>)s.SerializeU32)(v.flags);
            s.SerializeFieldName("flags_merged");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.flagsMerged);
            s.SerializeFieldName("affine");
            ((Action<byte[]>)s.SerializeBytes)(v.affine);
        }

        public static ObjectRef Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                ptr = new Field<uint?>(null),
                flags = new Field<uint>(),
                flagsMerged = new Field<uint?>(null),
                affine = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "flags":
                        fields.flags.Value = d.DeserializeU32();
                        break;
                    case "flags_merged":
                        fields.flagsMerged.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "affine":
                        fields.affine.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectRef", fieldName);
                }
            }
            return new ObjectRef(

                fields.name.Unwrap("ObjectRef", "name"),

                fields.ptr.Unwrap("ObjectRef", "ptr"),

                fields.flags.Unwrap("ObjectRef", "flags"),

                fields.flagsMerged.Unwrap("ObjectRef", "flagsMerged"),

                fields.affine.Unwrap("ObjectRef", "affine")

            );
        }
    }
}
