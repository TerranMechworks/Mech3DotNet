using System.Collections.Generic;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Unsafe.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// GameZ data.
    ///
    /// See <see cref="Read"/> for reading a <c>gamez.zbd</c> file.
    /// </summary>
    public class GameZ : IWritable
    {
        public GameType gameType;
        public List<Mech3DotNet.Types.Gamez.Texture> textures;
        public List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public List<Mech3DotNet.Types.Gamez.Model.Model> models;
        public List<Mech3DotNet.Types.Gamez.Nodes.Node> nodes;
        public Mech3DotNet.Types.Gamez.GameZMetadata metadata;

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

        public GameZ(
            GameType gameType,
            List<Mech3DotNet.Types.Gamez.Texture> textures,
            List<Mech3DotNet.Types.Gamez.Materials.Material> materials,
            List<Mech3DotNet.Types.Gamez.Model.Model> models,
            List<Mech3DotNet.Types.Gamez.Nodes.Node> nodes,
            Mech3DotNet.Types.Gamez.GameZMetadata metadata
        )
        {
            this.gameType = ValidateGameType(gameType);
            this.textures = textures;
            this.materials = materials;
            this.models = models;
            this.nodes = nodes;
            this.metadata = metadata;
        }

        /// <summary>Read a <c>gamez.zbd</c> file from the specified path.</summary>
        public static GameZ Read(string path, GameType gameType)
        {
            ValidateGameType(gameType);
            var gamez = ReadData(path, gameType, Interop.ReadGameZ, Mech3DotNet.Types.Gamez.GameZ.Converter);
            return new GameZ(
                gameType,
                gamez.textures,
                gamez.materials,
                gamez.models,
                gamez.nodes,
                gamez.metadata
            );
        }

        /// <summary>Write a <c>gamez.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            var gameType = ValidateGameType(this.gameType);
            var gamez = new Mech3DotNet.Types.Gamez.GameZ(
                this.textures,
                this.materials,
                this.models,
                this.nodes,
                this.metadata
            );
            WriteData(path, gameType, Interop.WriteGameZ, gamez, Mech3DotNet.Types.Gamez.GameZ.Converter);
        }
    }
}
