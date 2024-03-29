using System.Collections.Generic;
using Mech3DotNet.Types.Anim;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// MW animation data.
    ///
    /// See <see cref="Read"/> for reading a MW <c>anim.zbd</c> file.
    /// </summary>
    public class AnimMw : IWritable
    {
        public Dictionary<string, AnimDef> animations;
        public AnimMetadata metadata;

        public AnimMw(Dictionary<string, AnimDef> animations, AnimMetadata metadata)
        {
            this.animations = animations ?? throw new System.ArgumentNullException(nameof(animations));
            this.metadata = metadata ?? throw new System.ArgumentNullException(nameof(metadata));
        }

        private static Dictionary<string, AnimDef> ReadRaw(string path, out byte[] manifest_data)
        {
            var animations = new Dictionary<string, AnimDef>();
            manifest_data = Helpers.ReadArchive(path, GameType.MW, "metadata.bin", Interop.ReadAnim, (string name, byte[] data) =>
            {
                var anim = Interop.Deserialize(data, AnimDef.Converter);
                animations.Add(name, anim);
            });
            return animations;
        }

        /// <summary>
        /// Read a MW <c>anim.zbd</c> file from the specified path, discarding
        /// the manifest.
        ///
        /// Without the manifest, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, AnimDef> ReadAsDict(string path)
        {
            return ReadRaw(path, out _);
        }

        /// <summary>Read a MW <c>anim.zbd</c> file from the specified path.</summary>
        public static AnimMw Read(string path)
        {
            var animations = ReadRaw(path, out var manifest_data);
            var metadata = Interop.Deserialize(manifest_data, AnimMetadata.Converter);
            return new AnimMw(animations, metadata);
        }

        /// <summary>Write a MW <c>anim.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            var manifest_data = Interop.Serialize(metadata, AnimMetadata.Converter);
            Helpers.WriteArchive(path, GameType.MW, manifest_data, Interop.WriteAnim, (string name) =>
            {
                var anim = animations[name];
                return Interop.Serialize(anim, AnimDef.Converter);
            });
        }
    }
}
