using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataPm : IWritable
    {
        public static GameZDataPm Read(string path)
        {
            return ReadData(path, GameType.PM, Interop.ReadGameZ, Converter);
        }

        public void Write(string path)
        {
            WriteData(path, GameType.PM, Interop.WriteGameZ, this, Converter);
        }
    }
}
