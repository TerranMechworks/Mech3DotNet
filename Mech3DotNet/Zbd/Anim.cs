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
        public OrderedDict<AnimDef> animations;
        public OrderedDict<SiScript> siScripts;

        public AnimMission mission;
        public float gravity;
        public System.DateTime? datetime = null;
        public List<AnimDefFile> animList;

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
            OrderedDict<AnimDef> animations,
            OrderedDict<SiScript> siScripts,
            AnimMission mission,
            float gravity,
            System.DateTime? datetime,
            List<AnimDefFile> animList
        )
        {
            this.gameType = ValidateGameType(gameType);
            this.animations = animations ?? throw new System.ArgumentNullException(nameof(animations));
            this.siScripts = siScripts ?? throw new System.ArgumentNullException(nameof(siScripts));
            this.mission = mission;
            this.gravity = gravity;
            this.datetime = datetime;
            this.animList = animList;
        }

        /// <summary>Read a <c>anim.zbd</c> file from the specified path.</summary>
        public static Anim Read(string path, GameType gameType)
        {
            ValidateGameType(gameType);
            var animationsByName = new Dictionary<string, AnimDef>();
            var siScriptsByName = new Dictionary<string, SiScript>();
            var manifest_data = Helpers.ReadArchive(path, gameType, "metadata.bin", Interop.ReadAnim, (string name, byte[] data) =>
            {
                if (name.EndsWith(".zan"))
                {
                    var siScript = Interop.Deserialize(data, SiScript.Converter);
                    siScriptsByName.Add(name, siScript);
                }
                else
                {
                    var anim = Interop.Deserialize(data, AnimDef.Converter);
                    animationsByName.Add(name, anim);
                }
            });

            var metadata = Interop.Deserialize(manifest_data, AnimMetadata.Converter);

            var animations = new OrderedDict<AnimDef>();
            foreach (var key in metadata.animDefNames)
            {
                var value = animationsByName[key];
                animations.Add(key, value);
            }

            var siScripts = new OrderedDict<SiScript>();
            foreach (var key in metadata.scriptNames)
            {
                var value = siScriptsByName[key];
                siScripts.Add(key, value);
            }

            return new Anim(gameType, animations, siScripts, metadata.mission, metadata.gravity, metadata.datetime, metadata.animList);
        }

        /// <summary>Write a MW <c>anim.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            var gameType = ValidateGameType(this.gameType);

            var animDefNames = new List<string>();
            foreach (var kv in animations)
                animDefNames.Add(kv.Key);
            var scriptNames = new List<string>();
            foreach (var kv in siScripts)
                scriptNames.Add(kv.Key);

            var metadata = new AnimMetadata(
                mission,
                gravity,
                datetime,
                animDefNames,
                scriptNames,
                animList
            );
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
