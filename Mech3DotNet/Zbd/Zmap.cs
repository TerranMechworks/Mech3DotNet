using Mech3DotNet.Unsafe;
using static Mech3DotNet.Unsafe.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// Zmap data.
    ///
    /// See <see cref="Read"/> for reading a <c>m*.zmap</c> file.
    /// </summary>
    public partial class Zmap : IWritable
    {
        /// <summary>Read a <c>m*.zmap</c> file from the specified path.</summary>
        public static Zmap Read(string path)
        {
            return ReadData(path, GameType.RC, Interop.ReadZmap, Converter);
        }

        /// <summary>Write a <c>m*.zmap</c> file to the specified path.</summary>
        public void Write(string path)
        {
            WriteData(path, GameType.RC, Interop.WriteZmap, this, Converter);
        }
    }
}
