using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
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

    public class TextureArchive
    {
        public Dictionary<string, byte[]> textureData;
        public List<TextureInfo> textureInfos;
        public List<PaletteData> globalPalettes;

        public TextureArchive(Dictionary<string, byte[]> textureData, List<TextureInfo> textureInfos, List<PaletteData> globalPalettes)
        {
            this.textureData = textureData;
            this.textureInfos = textureInfos;
            this.globalPalettes = globalPalettes;
        }
    }

    public class Textures
    {
        protected static Dictionary<string, byte[]> ReadRaw(string inputPath, out byte[] manifest)
        {
            var textures = new Dictionary<string, byte[]>();
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            ExceptionDispatchInfo? ex = null;
            byte[]? capture = null;
            var res = Interop.ReadTextures(inputPath, (IntPtr namePointer, ulong nameLength, IntPtr dataPointer, ulong dataLength) =>
            {
                try
                {
                    var name = Interop.DecodeString(namePointer, nameLength);
                    var data = Interop.DecodeBytes(dataPointer, dataLength);
                    if (name == "manifest.json")
                        capture = data;
                    else
                        textures.Add(name, data);
                    return 0;
                }
                catch (Exception e)
                {
                    ex = ExceptionDispatchInfo.Capture(e);
                    return -1;
                }
            });
            if (res != 0)
            {
                if (ex != null)
                    ex.Throw();
                else
                    Interop.ThrowLastError();
            }
            if (capture == null)
                throw new InvalidOperationException("manifest is null after reading");
            manifest = capture;
            return textures;
        }

        public static Dictionary<string, Texture> Read(string inputPath)
        {
            var datas = ReadRaw(inputPath, out byte[] bmanifest);
            var manifest = Interop.Deserialize<TextureManifest>(bmanifest);
            var textures = new Dictionary<string, Texture>(manifest.textureInfos.Count);
            foreach (var info in manifest.textureInfos)
            {
                var data = datas[info.name];
                datas.Remove(info.name);
                textures.Add(info.name, new Texture(info, data));
            }
            if (datas.Count != 0)
                throw new InvalidOperationException($"{datas.Count} textures not used in manifest");
            return textures;
        }

        public static TextureArchive ReadArchive(string inputPath)
        {
            var datas = ReadRaw(inputPath, out byte[] bmanifest);
            var manifest = Interop.Deserialize<TextureManifest>(bmanifest);
            return new TextureArchive(datas, manifest.textureInfos, manifest.globalPalettes);
        }

        protected static void WriteRaw(string outputPath, byte[] manifest, Dictionary<string, byte[]> textures)
        {
            if (outputPath == null)
                throw new ArgumentNullException(nameof(outputPath));
            var manifestLength = (ulong)manifest.Length;
            ExceptionDispatchInfo? ex = null;
            int res;
            using (var manifestPointer = new PinnedGCHandle(manifest))
            {
                res = Interop.WriteTextures(outputPath, manifestPointer, manifestLength, (IntPtr namePointer, ulong nameLength, IntPtr buffer) =>
                {
                    try
                    {
                        var name = Interop.DecodeString(namePointer, nameLength);
                        var data = textures[name];
                        var dataLength = (ulong)data.Length;
                        using (var dataPointer = new PinnedGCHandle(data))
                        {
                            Interop.BufferSetData(buffer, dataPointer, dataLength);
                        }
                        return 0;
                    }
                    catch (Exception e)
                    {
                        ex = ExceptionDispatchInfo.Capture(e);
                        return -1;
                    }
                });
            }
            if (res != 0)
            {
                if (ex != null)
                    ex.Throw();
                else
                    Interop.ThrowLastError();
            }
        }

        public static void WriteArchive(string outputPath, TextureArchive archive)
        {
            var manifest = new TextureManifest(archive.textureInfos, archive.globalPalettes);
            var data = Interop.Serialize(manifest);
            WriteRaw(outputPath, data, archive.textureData);
        }
    }
}
