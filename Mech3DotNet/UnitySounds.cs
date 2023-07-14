using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    /// <summary>Sound data read in a Unity-compatible manner.</summary>
    public static class UnitySounds
    {
        public delegate void ReadSoundCb(string name, int channels, int frequency, float[] samples);

        /// <summary>
        /// Read a sound archive (soundsL.zbd, soundsH.zbd), converted into Unity-compatible data.
        ///
        /// The callback is invoked multiple times for each sound in the archive.
        /// </summary>
        public static void ReadSoundsAsWav(string inputPath, GameType gameType, ReadSoundCb readCallback)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            var gameTypeId = Helpers.GameTypeToId(gameType);
            ExceptionDispatchInfo? ex = null;
            var res = Interop.ReadSoundsAsWav(
                inputPath,
                gameTypeId,
                (IntPtr namePtr, ulong nameLen, int channels, int frequency, IntPtr samplePtr, ulong sampleLen) =>
                {
                    try
                    {
                        var name = Interop.DecodeString(namePtr, nameLen);
                        var length = Convert.ToInt32(sampleLen);
                        var samples = new float[length];
                        Marshal.Copy(samplePtr, samples, 0, length);
                        readCallback(name, channels, frequency, samples);
                        return 0;
                    }
                    catch (Exception e)
                    {
                        ex = ExceptionDispatchInfo.Capture(e);
                        return -1;
                    }
                });
            if (res != 0)
            {
                if (ex != null)
                    ex.Throw();
                else
                    Interop.ThrowLastError();
            }
        }

        /// <summary>
        /// Read a sound file (*.wav), converted into Unity-compatible data.
        ///
        /// The callback is invoked at most once.
        /// </summary>
        public static void ReadSoundAsWav(string inputPath, ReadSoundCb readCallback)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            ExceptionDispatchInfo? ex = null;
            var res = Interop.ReadSoundAsWav(
                inputPath,
                (int channels, int frequency, IntPtr samplePtr, ulong sampleLen) =>
                {
                    try
                    {
                        var name = System.IO.Path.GetFileName(inputPath);
                        var length = Convert.ToInt32(sampleLen);
                        var samples = new float[length];
                        Marshal.Copy(samplePtr, samples, 0, length);
                        readCallback(name, channels, frequency, samples);
                        return 0;
                    }
                    catch (Exception e)
                    {
                        ex = ExceptionDispatchInfo.Capture(e);
                        return -1;
                    }
                });
            if (res != 0)
            {
                if (ex != null)
                    ex.Throw();
                else
                    Interop.ThrowLastError();
            }
        }
    }
}
