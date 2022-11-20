using System;
using System.Runtime.InteropServices;

namespace Mech3DotNet.Unsafe
{
    public class Interop
    {
        // See https://docs.microsoft.com/en-us/dotnet/standard/native-interop/cross-platform
        private const string MECH3AX = @"mech3ax-0.6.0";
        private const UnmanagedType PStr = UnmanagedType.LPUTF8Str;

        public delegate void DataCb(IntPtr pointer, ulong length);
        public delegate int NameDataCb(IntPtr name, ulong nlength, IntPtr data, ulong dlength);
        public delegate int NameBufferCb(IntPtr name, ulong nlength, IntPtr buffer);
        public delegate int WaveArchiveCb(IntPtr namePtr, ulong nameLen, int channels, int frequency, IntPtr samplePtr, ulong sampleLen);
        public delegate int WaveFileCb(int channels, int frequency, IntPtr samplePtr, ulong sampleLen);

        [DllImport(MECH3AX, EntryPoint = "last_error_length")]
        public static extern int LastErrorLength();

        [DllImport(MECH3AX, EntryPoint = "last_error_message")]
        public static extern int LastErrorMessage(IntPtr pointer, int length);

        [DllImport(MECH3AX, EntryPoint = "buffer_set_data")]
        public static extern void BufferSetData(IntPtr buffer, IntPtr pointer, ulong length);

        [DllImport(MECH3AX, EntryPoint = "read_interp")]
        public static extern int ReadInterp(
            [MarshalAs(PStr)] string filename,
            // interp.zbd has no difference between games, it's just for consistency
            int game_type_ignored,
            DataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_interp")]
        public static extern int WriteInterp(
            [MarshalAs(PStr)] string filename,
            // interp.zbd has no difference between games, it's just for consistency
            int game_type_ignored,
            IntPtr pointer,
            ulong length);

        [DllImport(MECH3AX, EntryPoint = "read_messages")]
        public static extern int ReadMessages(
            [MarshalAs(PStr)] string filename,
            int game_type,
            DataCb callback);

        // no write_messages

        [DllImport(MECH3AX, EntryPoint = "read_sounds")]
        public static extern int ReadSounds(
            [MarshalAs(PStr)] string filename,
            int game_type,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_sounds")]
        public static extern int WriteSounds(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_sounds_as_wav")]
        public static extern int ReadSoundsAsWav(
            [MarshalAs(PStr)] string filename,
            int game_type,
            WaveArchiveCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_sound_as_wav")]
        public static extern int ReadSoundAsWav(
            [MarshalAs(PStr)] string filename,
            WaveFileCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_reader")]
        public static extern int ReadReader(
            [MarshalAs(PStr)] string filename,
            int game_type,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_reader")]
        public static extern int WriteReader(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_reader_raw")]
        public static extern int ReadReaderRaw(
            [MarshalAs(PStr)] string filename,
            int game_type,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_reader_raw")]
        public static extern int WriteReaderRaw(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_motion")]
        public static extern int ReadMotion(
            [MarshalAs(PStr)] string filename,
            int game_type,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_motion")]
        public static extern int WriteMotion(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_mechlib")]
        public static extern int ReadMechlib(
            [MarshalAs(PStr)] string filename,
            int game_type,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_mechlib")]
        public static extern int WriteMechlib(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_textures")]
        public static extern int ReadTextures(
            [MarshalAs(PStr)] string filename,
            int game_type,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_textures")]
        public static extern int WriteTextures(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_gamez")]
        public static extern int ReadGameZ(
            [MarshalAs(PStr)] string filename,
            int game_type,
            DataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_gamez")]
        public static extern int WriteGameZ(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr pointer,
            ulong length);

        [DllImport(MECH3AX, EntryPoint = "read_anim")]
        public static extern int ReadAnim(
            [MarshalAs(PStr)] string filename,
            int game_type,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_anim")]
        public static extern int WriteAnim(
            [MarshalAs(PStr)] string filename,
            int game_type,
            IntPtr metadata_ptr,
            ulong metadata_len,
            NameBufferCb callback);

        public static string? GetLastError()
        {
            var length = LastErrorLength();
            if (length == 0)
                return null;
            var buffer = new byte[length];
            int res;
            using (var pointer = new PinnedGCHandle(buffer))
            {
                res = LastErrorMessage(pointer, length);
            }
            if (res < 0)
                return null;
            // res = length - 1; buffer is null terminated but this is unneeded in C#
            return System.Text.Encoding.UTF8.GetString(buffer, 0, res);
        }

        public static void ThrowLastError()
        {
            var message = GetLastError();
            if (message == null)
                throw new InvalidOperationException("No last error");
            else
                throw new RustException(message);
        }

        public static byte[] DecodeBytes(IntPtr pointer, ulong length)
        {
            var size = Convert.ToInt32(length);
            var buffer = new byte[size];
            Marshal.Copy(pointer, buffer, 0, size);
            return buffer;
        }

        public static string DecodeString(IntPtr pointer, ulong length)
        {
            return System.Text.Encoding.UTF8.GetString(DecodeBytes(pointer, length));
        }

        public static T Deserialize<T>(byte[] json) where T : class
        {
            T? value = System.Text.Json.JsonSerializer.Deserialize<T>(json, Mech3DotNet.Json.Converters.Options.GlobalOptions);
            if (value is null)
                throw new InvalidOperationException("Deserialize returned null");
            return value;
        }

        public static byte[] Serialize<T>(T value)
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value, Mech3DotNet.Json.Converters.Options.GlobalOptions);
        }
    }
}
