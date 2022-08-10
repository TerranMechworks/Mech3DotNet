using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class Sounds
    {
        private static Dictionary<string, byte[]> ReadRaw(string inputPath, bool isPM, out byte[] manifest)
        {
            var sounds = new Dictionary<string, byte[]>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.read_sounds, (string name, byte[] data) =>
            {
                // there are duplicate sounds in the archive
                sounds[name] = data;
            });
            return sounds;
        }

        /// <summary>
        /// Read a sound archive (soundsL.zbd, soundsH.zbd) from the base game.
        /// </summary>
        public static Archive<byte[]> ReadArchiveMW(string inputPath)
        {
            var items = ReadRaw(inputPath, false, out byte[] manifest);
            return new Archive<byte[]>(items, manifest);
        }

        /// <summary>
        /// Read a sound archive (soundsL.zbd, soundsH.zbd) from the expansion.
        /// </summary>
        public static Archive<byte[]> ReadArchivePM(string inputPath)
        {
            var items = ReadRaw(inputPath, true, out byte[] manifest);
            return new Archive<byte[]>(items, manifest);
        }

        private static void WriteRaw(string outputPath, bool isPM, Archive<byte[]> archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.write_sounds, (string name) =>
            {
                return archive.items[name];
            });
        }

        /// <summary>
        /// Write a sound archive (soundsL.zbd, soundsH.zbd) from the base game.
        /// </summary>
        public static void WriteArchiveMW(string outputPath, Archive<byte[]> archive)
        {
            WriteRaw(outputPath, false, archive);
        }

        /// <summary>
        /// Write a sound archive (soundsL.zbd, soundsH.zbd) from the expansion.
        /// </summary>
        public static void WriteArchivePM(string outputPath, Archive<byte[]> archive)
        {
            WriteRaw(outputPath, true, archive);
        }

        public delegate void ReadWaveCb(string name, int channels, int frequency, float[] samples);

        /// <summary>
        /// Read a sound archive (soundsL.zbd, soundsH.zbd), parsed into Unity-compatible sound.
        /// </summary>
        public static void ReadSoundsAsWav(string inputPath, bool isPM, ReadWaveCb readCallback)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            Exception? ex = null;
            var res = Interop.read_sounds_as_wav(
                inputPath,
                isPM,
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
                        ex = e;
                        return -1;
                    }
                });
            if (res != 0)
            {
                if (ex != null)
                    throw ex;
                else
                    Interop.ThrowLastError();
            }
        }

        /// <summary>
        /// Read a sound file (*.wav), parsed into Unity-compatible sound.
        /// </summary>
        public static void ReadSoundAsWav(string inputPath, ReadWaveCb readCallback)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            Exception? ex = null;
            var res = Interop.read_sound_as_wav(
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
                        ex = e;
                        return -1;
                    }
                });
            if (res != 0)
            {
                if (ex != null)
                    throw ex;
                else
                    Interop.ThrowLastError();
            }
        }
    }
}
