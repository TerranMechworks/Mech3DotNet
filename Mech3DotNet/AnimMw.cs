using System.Collections.Generic;
using Mech3DotNet.Types.Anim;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    /// <summary>MW animation data.</summary>
    public class AnimMw : IWritable
    {
        public Dictionary<string, AnimDef> animations;
        public AnimMetadata metadata;

        public AnimMw(Dictionary<string, AnimDef> animations, AnimMetadata metadata)
        {
            this.animations = animations ?? throw new System.ArgumentNullException(nameof(animations));
            this.metadata = metadata ?? throw new System.ArgumentNullException(nameof(metadata));
        }

        private static Dictionary<string, AnimDef> ReadRaw(string inputPath, out byte[] manifest_data)
        {
            var animations = new Dictionary<string, AnimDef>();
            manifest_data = Helpers.ReadArchive(inputPath, GameType.MW, "metadata.bin", Interop.ReadAnim, (string name, byte[] data) =>
            {
                var anim = Interop.Deserialize(data, AnimDef.Converter);
                animations.Add(name, anim);
            });
            return animations;
        }

        /// <summary>
        /// Read MW animation data, discarding the manifest.
        ///
        /// Without the manifest, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, AnimDef> ReadAsDict(string inputPath)
        {
            return ReadRaw(inputPath, out _);
        }

        /// <summary>Read MW animation data, retaining the manifest.</summary>
        public static AnimMw Read(string inputPath)
        {
            var animations = ReadRaw(inputPath, out var manifest_data);
            var metadata = Interop.Deserialize(manifest_data, AnimMetadata.Converter);
            return new AnimMw(animations, metadata);
        }

        /// <summary>Write MW animation data.</summary>
        public void Write(string outputPath)
        {
            var manifest_data = Interop.Serialize(metadata, AnimMetadata.Converter);
            Helpers.WriteArchive(outputPath, GameType.MW, manifest_data, Interop.WriteAnim, (string name) =>
            {
                var anim = animations[name];
                return Interop.Serialize(anim, AnimDef.Converter);
            });
        }
    }
}
