using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataCs : IWritable
    {
        public static GameZDataCs Read(string path)
        {
            return ReadData(path, GameType.CS, Interop.ReadGameZ, Converter);
        }

        public void Write(string path)
        {
            WriteData(path, GameType.CS, Interop.WriteGameZ, this, Converter);
        }
    }
}
