using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;

namespace Mech3DotNet.Json
{
    public enum TexturePaletteType
    {
        None,
        Local,
        Global,
    }

    [JsonConverter(typeof(DiscriminatedUnionConverter<TexturePalette>))]
    public class TexturePalette : DiscriminatedUnion
    {
        [Guid("DF240ABE-A5AA-44E3-BACC-B166278FF42D")]
        public sealed class None
        {
            public None() { }
        }

        [JsonConverter(typeof(TransparentConverter<Local>))]
        [Guid("2CC6F12E-DB78-45AB-8E90-2C2561845C1A")]
        public sealed class Local
        {
            public byte[] palette;

            public Local(byte[] palette)
            {
                this.palette = palette ?? throw new ArgumentNullException(nameof(palette));
            }
        }

        [JsonConverter(typeof(TupleConverter<Global>))]
        [Guid("E672B377-BB2C-48B1-B37B-E2F1FAB000A7")]
        public sealed class Global
        {
            public int index;
            public ushort length;

            public Global(int index, ushort length)
            {
                this.index = index;
                this.length = length;
            }
        }

        public TexturePaletteType Variant { get; protected set; }

        public TexturePalette(None none)
        {
            value = none ?? throw new ArgumentNullException(nameof(none));
            Variant = TexturePaletteType.None;
        }

        public TexturePalette(Local local)
        {
            value = local ?? throw new ArgumentNullException(nameof(local));
            Variant = TexturePaletteType.Local;
        }

        public TexturePalette(Global global)
        {
            value = global ?? throw new ArgumentNullException(nameof(global));
            Variant = TexturePaletteType.Global;
        }
    }
}
