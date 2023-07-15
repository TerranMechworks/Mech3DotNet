using Mech3DotNet.Unsafe;
using static Mech3DotNet.Unsafe.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// PM GameZ data.
    ///
    /// See <see cref="Read"/> for reading a PM <c>gamez.zbd</c> file.
    /// </summary>
    public partial class GameZDataPm : IWritable
    {
        /// <summary>Read a PM <c>gamez.zbd</c> file from the specified path.</summary>
        public static GameZDataPm Read(string path)
        {
            return ReadData(path, GameType.PM, Interop.ReadGameZ, Converter);
        }

        /// <summary>Write a PM <c>gamez.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            WriteData(path, GameType.PM, Interop.WriteGameZ, this, Converter);
        }
    }
}
