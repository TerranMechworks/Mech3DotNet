using Mech3DotNet.Unsafe;
using static Mech3DotNet.Unsafe.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// RC GameZ data.
    ///
    /// See <see cref="Read"/> for reading a RC <c>gamez.zbd</c> file.
    /// </summary>
    public partial class GameZDataRc : IWritable
    {
        /// <summary>Read a RC <c>gamez.zbd</c> file from the specified path.</summary>
        public static GameZDataRc Read(string path)
        {
            return ReadData(path, GameType.RC, Interop.ReadGameZ, Converter);
        }

        /// <summary>Write a RC <c>gamez.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            WriteData(path, GameType.RC, Interop.WriteGameZ, this, Converter);
        }
    }
}
