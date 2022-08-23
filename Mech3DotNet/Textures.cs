using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class TexturePackage
    {
        public Dictionary<string, byte[]> textureData;
        public List<TextureInfo> textureInfos;
        public List<PaletteData> globalPalettes;

        public TexturePackage(Dictionary<string, byte[]> textureData, List<TextureInfo> textureInfos, List<PaletteData> globalPalettes)
        {
            this.textureData = textureData;
            this.textureInfos = textureInfos;
            this.globalPalettes = globalPalettes;
        }

        public TexturePackage(Dictionary<string, byte[]> textureData, byte[] bmanifest)
        {
            var manifest = Interop.Deserialize<TextureManifest>(bmanifest);
            this.textureData = textureData;
            this.textureInfos = manifest.textureInfos;
            this.globalPalettes = manifest.globalPalettes;
        }

        public byte[] SerializeManifest()
        {
            var manifest = new TextureManifest(textureInfos, globalPalettes);
            return Interop.Serialize(manifest);
        }
    }

    public sealed class Texture
    {
        public TextureInfo info;
        public byte[] data;

        public Texture(TextureInfo info, byte[] data)
        {
            this.info = info;
            this.data = data;
        }
    }

    public static class Textures
    {
        private static Dictionary<string, byte[]> ReadRaw(string inputPath, out byte[] manifest)
        {
            var textureData = new Dictionary<string, byte[]>();
            // textures have no difference between MW and PM, it's just for consistency
            manifest = Helpers.ReadArchiveRaw(inputPath, false, "manifest.json", Interop.ReadTextures, (string name, byte[] data) =>
            {
                textureData.Add(name, data);
            });
            return textureData;
        }

        // This fuses the information from the manifest with the texture data.
        // It also disregards global palette information.
        public static Dictionary<string, Texture> Read(string inputPath)
        {
            var textureData = ReadRaw(inputPath, out byte[] bmanifest);
            var manifest = Interop.Deserialize<TextureManifest>(bmanifest);
            var fused = new Dictionary<string, Texture>(manifest.textureInfos.Count);
            foreach (var info in manifest.textureInfos)
            {
                var data = textureData[info.name];
                textureData.Remove(info.name);
                fused.Add(info.name, new Texture(info, data));
            }
            if (textureData.Count != 0)
                throw new InvalidOperationException($"{textureData.Count} textures not used in manifest");
            return fused;
        }

        public static TexturePackage ReadPackage(string inputPath)
        {
            var textureData = ReadRaw(inputPath, out byte[] manifest);
            return new TexturePackage(textureData, manifest);
        }

        private static void WriteRaw(string outputPath, TexturePackage package)
        {
            var manifest = package.SerializeManifest();
            // textures have no difference between MW and PM, it's just for consistency
            Helpers.WriteArchiveRaw(outputPath, false, manifest, Interop.WriteTextures, (string name) =>
            {
                return package.textureData[name];
            });
        }

        public static void WritePackage(string outputPath, TexturePackage package)
        {
            WriteRaw(outputPath, package);
        }
    }
}
