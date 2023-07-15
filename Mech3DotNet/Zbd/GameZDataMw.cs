using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataMw : IWritable
    {
        public static GameZDataMw Read(string path)
        {
            return ReadData(path, GameType.MW, Interop.ReadGameZ, Converter);
        }

        public void Write(string path)
        {
            WriteData(path, GameType.MW, Interop.WriteGameZ, this, Converter);
        }
    }
}
