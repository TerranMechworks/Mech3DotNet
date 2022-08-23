using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Json;
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
            this.metadata = Interop.Deserialize<AnimMetadata>(metadata);
        }

        public byte[] SerializeMetadata() => Interop.Serialize(metadata);
    }

    public static class Anim
    {
        private static Dictionary<string, AnimDef> ReadRaw(string inputPath, bool isPM, out byte[] metadata)
        {
            var animations = new Dictionary<string, AnimDef>();
            metadata = Helpers.ReadArchiveRaw(inputPath, isPM, "metadata.json", Interop.ReadAnim, (string name, byte[] data) =>
            {
                var anim = Interop.Deserialize<AnimDef>(data);
                animations.Add(name, anim);
            });
            return animations;
        }

        public static Dictionary<string, AnimDef> ReadMW(string inputPath)
        {
            return ReadRaw(inputPath, false, out _);
        }

        public static AnimPackage ReadPackageMW(string inputPath)
        {
            var animations = ReadRaw(inputPath, false, out byte[] metadata);
            return new AnimPackage(animations, metadata);
        }

        private static void Write(string outputPath, bool isPM, AnimPackage package)
        {
            var metadata = package.SerializeMetadata();
            Helpers.WriteArchiveRaw(outputPath, isPM, metadata, Interop.WriteAnim, (string name) =>
            {
                var anim = package.animations[name];
                return Interop.Serialize(anim);
            });
        }

        public static void WritePackageMW(string outputPath, AnimPackage package)
        {
            Write(outputPath, false, package);
        }
    }
}
