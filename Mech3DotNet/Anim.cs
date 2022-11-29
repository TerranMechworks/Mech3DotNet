using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Types.Anim;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class AnimPackage
    {
        public Dictionary<string, AnimDef> animations;
        public AnimMetadata metadata;

        public AnimPackage(Dictionary<string, AnimDef> animations, AnimMetadata metadata)
        {
            this.animations = animations ?? throw new ArgumentNullException(nameof(animations));
            this.metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
        }

        public AnimPackage(Dictionary<string, AnimDef> animations, byte[] metadata)
        {
            this.animations = animations ?? throw new ArgumentNullException(nameof(animations));
            this.metadata = Interop.Deserialize(metadata, AnimMetadata.Converter);
        }

        public byte[] SerializeMetadata() => Interop.Serialize(metadata, AnimMetadata.Converter);
    }

    public static class Anim
    {
        private static Dictionary<string, AnimDef> ReadRaw(string inputPath, GameType gameType, out byte[] metadata)
        {
            var animations = new Dictionary<string, AnimDef>();
            metadata = Helpers.ReadArchiveRaw(inputPath, gameType, "metadata.bin", Interop.ReadAnim, (string name, byte[] data) =>
            {
                var anim = Interop.Deserialize(data, AnimDef.Converter);
                animations.Add(name, anim);
            });
            return animations;
        }

        public static Dictionary<string, AnimDef> ReadMW(string inputPath)
        {
            return ReadRaw(inputPath, GameType.MW, out _);
        }

        public static AnimPackage ReadPackageMW(string inputPath)
        {
            var animations = ReadRaw(inputPath, GameType.MW, out byte[] metadata);
            return new AnimPackage(animations, metadata);
        }

        private static void Write(string outputPath, GameType gameType, AnimPackage package)
        {
            var metadata = package.SerializeMetadata();
            Helpers.WriteArchiveRaw(outputPath, gameType, metadata, Interop.WriteAnim, (string name) =>
            {
                var anim = package.animations[name];
                return Interop.Serialize(anim, AnimDef.Converter);
            });
        }

        public static void WritePackageMW(string outputPath, AnimPackage package)
        {
            Write(outputPath, GameType.MW, package);
        }
    }
}
