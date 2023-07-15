using Mech3DotNet.Unsafe;
using static Mech3DotNet.Unsafe.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// MW GameZ data.
    ///
    /// See <see cref="Read"/> for reading a MW <c>gamez.zbd</c> file.
    /// </summary>
    public partial class GameZDataMw : IWritable
    {
        /// <summary>Read a MW <c>gamez.zbd</c> file from the specified path.</summary>
        public static GameZDataMw Read(string path)
        {
            return ReadData(path, GameType.MW, Interop.ReadGameZ, Converter);
        }

        /// <summary>Write a MW <c>gamez.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            WriteData(path, GameType.MW, Interop.WriteGameZ, this, Converter);
        }
    }
}
