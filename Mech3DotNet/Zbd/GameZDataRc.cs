using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataRc : IWritable
    {
        public static GameZDataRc Read(string path)
        {
            return ReadData(path, GameType.RC, Interop.ReadGameZ, Converter);
        }

        public void Write(string path)
        {
            WriteData(path, GameType.RC, Interop.WriteGameZ, this, Converter);
        }
    }
}
