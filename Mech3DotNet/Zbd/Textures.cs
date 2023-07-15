using System.Collections.Generic;
using Mech3DotNet.Types.Image;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>Texture data.</summary>
    public class Textures : IWritable
    {
        public Dictionary<string, byte[]> textureData;
        public List<TextureInfo> textureInfos;
        public List<PaletteData> globalPalettes;

        public Textures(Dictionary<string, byte[]> textureData, List<TextureInfo> textureInfos, List<PaletteData> globalPalettes)
        {
            this.textureData = textureData;
            this.textureInfos = textureInfos;
            this.globalPalettes = globalPalettes;
        }

        private static Dictionary<string, byte[]> ReadRaw(string path, out byte[] manifest_data)
        {
            var textureData = new Dictionary<string, byte[]>();
            manifest_data = Helpers.ReadArchive(path, Helpers.IGNORED, Helpers.MANIFEST, Interop.ReadTextures, (string name, byte[] data) =>
            {
                textureData.Add(name, data);
            });
            return textureData;
        }

        /// <summary>
        /// Read texture data, fusing texture infos with texture data and
        /// discarding other manifest data.
        ///
        /// Without the manifest, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, FusedTexture> ReadAsDict(string path)
        {
            var textureData = ReadRaw(path, out var manifest_data);
            var manifest = Interop.Deserialize(manifest_data, TextureManifest.Converter);
            var fused = new Dictionary<string, FusedTexture>(manifest.textureInfos.Count);
            foreach (var info in manifest.textureInfos)
            {
                var data = textureData[info.name];
                textureData.Remove(info.name);
                fused.Add(info.name, new FusedTexture(info, data));
            }
            if (textureData.Count != 0)
                throw new System.InvalidOperationException($"{textureData.Count} textures not used in manifest");
            return fused;
        }

        /// <summary>Read texture data, retaining all manifest data.</summary>
        public static Textures Read(string path)
        {
            var textureData = ReadRaw(path, out var manifest_data);
            var manifest = Interop.Deserialize(manifest_data, TextureManifest.Converter);
            return new Textures(textureData, manifest.textureInfos, manifest.globalPalettes);
        }

        /// <summary>Write texture data.</summary>
        public void Write(string path)
        {
            var manifest = new TextureManifest(textureInfos, globalPalettes);
            var manifest_data = Interop.Serialize(manifest, TextureManifest.Converter);
            Helpers.WriteArchive(path, Helpers.IGNORED, manifest_data, Interop.WriteTextures, (string name) =>
            {
                return textureData[name];
            });
        }
    }
}
