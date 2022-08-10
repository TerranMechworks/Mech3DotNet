using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public enum MaterialType
    {
        Textured,
        Colored,
    }

    [JsonConverter(typeof(DiscriminatedUnionConverter<Material>))]
    public class Material : IDiscriminatedUnion
    {
        [Guid("936D3B97-3F4C-4405-B401-0A9408886E45")]
        public class Textured
        {
            [JsonProperty("texture", Required = Required.Always)]
            public string texture;
            [JsonProperty("pointer", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
            public uint pointer = 0;
            [JsonProperty("cycle", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
            public CycleData? cycle = null;
            [JsonProperty("unk32", Required = Required.Always)]
            public uint unk32;
            [JsonProperty("flag", Required = Required.Always)]
            public bool flag;

            public Textured(string texture, uint pointer, CycleData? cycle, uint unk32, bool flag)
            {
                this.texture = texture;
                this.pointer = pointer;
                this.cycle = cycle;
                this.unk32 = unk32;
                this.flag = flag;
            }

            [JsonConstructor]
            private Textured() { }
        }

        [Guid("A6F6F442-012B-4184-AB98-796ACB064A1A")]
        public class Colored
        {
            [JsonProperty("color", Required = Required.Always)]
            public Color color;
            [JsonProperty("unk00", Required = Required.Always)]
            public byte unk00;
            [JsonProperty("unk32", Required = Required.Always)]
            public uint unk32;

            public Colored(Color color, byte unk00, uint unk32)
            {
                this.color = color;
                this.unk00 = unk00;
                this.unk32 = unk32;
            }

            [JsonConstructor]
            private Colored() { }
        }

        public Material(Textured textured)
        {
            value = textured;
            Variant = MaterialType.Textured;
        }

        public Material(Colored colored)
        {
            value = colored;
            Variant = MaterialType.Colored;
        }

        protected object value;
        public MaterialType Variant { get; protected set; }
        public bool Is<T>() where T : class { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() where T : class { return (T)value; }
        public object GetValue() { return value; }
    }
}
