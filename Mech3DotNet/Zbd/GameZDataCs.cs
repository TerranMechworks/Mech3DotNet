using Mech3DotNet.Unsafe;
using static Mech3DotNet.Unsafe.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// CS GameZ data.
    ///
    /// See <see cref="Read"/> for reading a CS <c>gamez.zbd</c> file.
    /// </summary>
    public partial class GameZDataCs : IWritable
    {
        /// <summary>Read a CS <c>gamez.zbd</c> file from the specified path.</summary>
        public static GameZDataCs Read(string path)
        {
            return ReadData(path, GameType.CS, Interop.ReadGameZ, Converter);
        }

        /// <summary>Write a CS <c>gamez.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            WriteData(path, GameType.CS, Interop.WriteGameZ, this, Converter);
        }
    }
}
