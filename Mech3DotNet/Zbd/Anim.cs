using System.Collections.Generic;
using Mech3DotNet.Types.Anim;
using Mech3DotNet.Types.Anim.AnimDef;
using Mech3DotNet.Types.Anim.SiScript;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// Animation data.
    ///
    /// See <see cref="Read"/> for reading a <c>anim.zbd</c> file.
    /// </summary>
    public class Anim : IWritable
    {
        public GameType gameType;
        public Dictionary<string, AnimDef> animations;
        public Dictionary<string, SiScript> siScripts;
        public AnimMetadata metadata;

        private static GameType ValidateGameType(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.MW:
                case GameType.PM:
                case GameType.RC:
                    return gameType;
                case GameType.CS:
                    throw new System.ArgumentException("unsupported game type");
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(GameType));
            }
        }

        public Anim(
            GameType gameType,
            Dictionary<string, AnimDef> animations,
            Dictionary<string, SiScript> siScripts,
            AnimMetadata metadata
        )
        {
            this.gameType = ValidateGameType(gameType);
            this.animations = animations ?? throw new System.ArgumentNullException(nameof(animations));
            this.siScripts = siScripts ?? throw new System.ArgumentNullException(nameof(siScripts));
            this.metadata = metadata ?? throw new System.ArgumentNullException(nameof(metadata));
        }

        /// <summary>Read a <c>anim.zbd</c> file from the specified path.</summary>
        public static Anim Read(string path, GameType gameType)
        {
            ValidateGameType(gameType);
            var animations = new Dictionary<string, AnimDef>();
            var siScripts = new Dictionary<string, SiScript>();
            var manifest_data = Helpers.ReadArchive(path, gameType, "metadata.bin", Interop.ReadAnim, (string name, byte[] data) =>
            {
                if (name.EndsWith(".zan"))
                {
                    var siScript = Interop.Deserialize(data, SiScript.Converter);
                    siScripts.Add(name, siScript);
                }
                else
                {
                    var anim = Interop.Deserialize(data, AnimDef.Converter);
                    animations.Add(name, anim);
                }
            });
            var metadata = Interop.Deserialize(manifest_data, AnimMetadata.Converter);
            return new Anim(gameType, animations, siScripts, metadata);
        }

        /// <summary>Write a MW <c>anim.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            var gameType = ValidateGameType(this.gameType);
            var manifest_data = Interop.Serialize(metadata, AnimMetadata.Converter);
            Helpers.WriteArchive(path, gameType, manifest_data, Interop.WriteAnim, (string name) =>
            {
                if (name.EndsWith(".zan"))
                {
                    var siScript = siScripts[name];
                    return Interop.Serialize(siScript, SiScript.Converter);
                }
                else
                {
                    var anim = animations[name];
                    return Interop.Serialize(anim, AnimDef.Converter);
                }
            });
        }
    }
}
