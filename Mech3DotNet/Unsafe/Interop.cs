using System;
using System.Runtime.InteropServices;

namespace Mech3DotNet.Unsafe
{
    public class Interop
    {
        private const String MECH3AX = @"mech3ax-0.4.2";
        private const UnmanagedType PStr = UnmanagedType.LPUTF8Str;

        public delegate void DataCb(IntPtr pointer, ulong length);
        public delegate int NameDataCb(IntPtr name, ulong nlength, IntPtr data, ulong dlength);
        public delegate int NameBufferCb(IntPtr name, ulong nlength, IntPtr buffer);
        public delegate int WaveArchiveCb(IntPtr namePtr, ulong nameLen, int channels, int frequency, IntPtr samplePtr, ulong sampleLen);
        public delegate int WaveFileCb(int channels, int frequency, IntPtr samplePtr, ulong sampleLen);

        [DllImport(MECH3AX)]
        public static extern int last_error_length();

        [DllImport(MECH3AX)]
        public static extern int last_error_message(IntPtr pointer, int length);

        [DllImport(MECH3AX)]
        public static extern void buffer_set_data(IntPtr buffer, IntPtr pointer, ulong length);

        [DllImport(MECH3AX)]
        public static extern int read_interp(
            [MarshalAs(PStr)] string filename,
            // interp.zbd has no difference between MW and PM, it's just for consistency
            [MarshalAs(UnmanagedType.Bool)] bool is_pm_ignored,
            DataCb callback);

        [DllImport(MECH3AX)]
        public static extern int write_interp(
            [MarshalAs(PStr)] string filename,
            // interp.zbd has no difference between MW and PM, it's just for consistency
            [MarshalAs(UnmanagedType.Bool)] bool is_pm_ignored,
            IntPtr pointer,
            ulong length);

        [DllImport(MECH3AX)]
        public static extern int read_messages(
            [MarshalAs(PStr)] string filename,
            DataCb callback);

        // no write_messages

        [DllImport(MECH3AX)]
        public static extern int read_sounds(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            NameDataCb callback);

        [DllImport(MECH3AX)]
        public static extern int write_sounds(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX)]
        public static extern int read_sounds_as_wav(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            WaveArchiveCb callback);

        [DllImport(MECH3AX)]
        public static extern int read_sound_as_wav(
            [MarshalAs(PStr)] string filename,
            WaveFileCb callback);

        [DllImport(MECH3AX)]
        public static extern int read_reader(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            NameDataCb callback);

        [DllImport(MECH3AX)]
        public static extern int write_reader(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX)]
        public static extern int read_motion(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            NameDataCb callback);

        [DllImport(MECH3AX)]
        public static extern int write_motion(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX)]
        public static extern int read_mechlib(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            NameDataCb callback);

        [DllImport(MECH3AX)]
        public static extern int write_mechlib(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX)]
        public static extern int read_textures(
            [MarshalAs(PStr)] string filename,
            NameDataCb callback);

        [DllImport(MECH3AX)]
        public static extern int write_textures(
            [MarshalAs(PStr)] string filename,
            IntPtr manifest_ptr,
            ulong manifest_len,
            NameBufferCb callback);

        [DllImport(MECH3AX)]
        public static extern int read_gamez(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            DataCb callback);

        [DllImport(MECH3AX)]
        public static extern int write_gamez(
            [MarshalAs(PStr)] string filename,
            [MarshalAs(UnmanagedType.Bool)] bool is_pm,
            IntPtr pointer,
            ulong length);

        public static String GetLastError()
        {
            var length = last_error_length();
            if (length == 0)
                return null;
            var buffer = new byte[length];
            int res;
            using (var pointer = new PinnedGCHandle(buffer))
            {
                res = last_error_message(pointer, length);
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

        public static string GetString(byte[] data)
        {
            return System.Text.Encoding.UTF8.GetString(data);
        }

        public static string DecodeString(IntPtr pointer, ulong length)
        {
            return GetString(DecodeBytes(pointer, length));
        }

        public static byte[] GetBytes(string value)
        {
            return System.Text.Encoding.UTF8.GetBytes(value);
        }
    }
}
