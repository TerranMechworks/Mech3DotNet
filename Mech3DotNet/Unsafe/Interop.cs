using System;
using System.Runtime.InteropServices;

namespace Mech3DotNet.Unsafe
{
    /// <summary>
    /// Raw, unsafe bindings to the mech3ax library.
    /// </summary>
    internal class Interop
    {
        // See https://docs.microsoft.com/en-us/dotnet/standard/native-interop/cross-platform
        private const string MECH3AX = "mech3ax-v0.7.0-rc2";
        private const UnmanagedType PStr = UnmanagedType.LPUTF8Str;
        private const UnmanagedType Usize = UnmanagedType.SysUInt;

        [DllImport(MECH3AX, EntryPoint = "buffer_set_data")]
        public static extern void BufferSetData(
            IntPtr bufPtr,
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);

        [DllImport(MECH3AX, EntryPoint = "last_error_length")]
        [return: MarshalAs(Usize)]
        public static extern UIntPtr LastErrorLength();

        [DllImport(MECH3AX, EntryPoint = "last_error_message")]
        [return: MarshalAs(Usize)]
        public static extern UIntPtr LastErrorMessage(
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);

        public delegate void DataCb(
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);

        public delegate int NameDataCb(
            IntPtr namePtr,
            [MarshalAs(Usize)]
            UIntPtr nameLen,
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);
        public delegate int NameBufferCb(
            IntPtr namePtr,
            [MarshalAs(Usize)]
            UIntPtr nameLen,
            IntPtr bufPtr);
        public delegate int WaveArchiveCb(
            IntPtr namePtr,
            [MarshalAs(Usize)]
            UIntPtr nameLen,
            int channels,
            int frequency,
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);
        public delegate int WaveFileCb(
            int channels,
            int frequency,
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);

        [DllImport(MECH3AX, EntryPoint = "read_interp")]
        public static extern int ReadInterp(
            [MarshalAs(PStr)]
            string filename,
            // no difference between games, it's just for consistency
            int gameTypeIdIgnored,
            DataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_interp")]
        public static extern int WriteInterp(
            [MarshalAs(PStr)]
            string filename,
            // no difference between games, it's just for consistency
            int gameTypeIdIgnored,
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);

        [DllImport(MECH3AX, EntryPoint = "read_messages")]
        public static extern int ReadMessages(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            DataCb callback);

        // no write_messages

        [DllImport(MECH3AX, EntryPoint = "read_sounds")]
        public static extern int ReadSounds(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_sounds")]
        public static extern int WriteSounds(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            IntPtr manifestPtr,
            [MarshalAs(Usize)]
            UIntPtr manifestLen,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_sounds_as_wav")]
        public static extern int ReadSoundsAsWav(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            WaveArchiveCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_sound_as_wav")]
        public static extern int ReadSoundAsWav(
            [MarshalAs(PStr)]
            string filename,
            WaveFileCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_reader")]
        public static extern int ReadReader(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_reader")]
        public static extern int WriteReader(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            IntPtr manifestPtr,
            [MarshalAs(Usize)]
            UIntPtr manifestLen,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_motion")]
        public static extern int ReadMotion(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_motion")]
        public static extern int WriteMotion(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            IntPtr manifestPtr,
            [MarshalAs(Usize)]
            UIntPtr manifestLen,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_mechlib")]
        public static extern int ReadMechlib(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_mechlib")]
        public static extern int WriteMechlib(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            IntPtr manifestPtr,
            [MarshalAs(Usize)]
            UIntPtr manifestLen,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_images")]
        public static extern int ReadImages(
            [MarshalAs(PStr)]
            string filename,
            // no difference between games, it's just for consistency
            int gameTypeId,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_images")]
        public static extern int WriteImages(
            [MarshalAs(PStr)]
            string filename,
            // no difference between games, it's just for consistency
            int gameTypeId,
            IntPtr manifestPtr,
            [MarshalAs(Usize)]
            UIntPtr manifestLen,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_gamez")]
        public static extern int ReadGameZ(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            DataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_gamez")]
        public static extern int WriteGameZ(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            IntPtr manifestPtr,
            [MarshalAs(Usize)]
            UIntPtr manifestLen);

        [DllImport(MECH3AX, EntryPoint = "read_anim")]
        public static extern int ReadAnim(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            NameDataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_anim")]
        public static extern int WriteAnim(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            IntPtr metadataPtr,
            [MarshalAs(Usize)]
            UIntPtr metadataLen,
            NameBufferCb callback);

        [DllImport(MECH3AX, EntryPoint = "read_zmap")]
        public static extern int ReadZmap(
            [MarshalAs(PStr)]
            string filename,
            int gameTypeId,
            DataCb callback);

        [DllImport(MECH3AX, EntryPoint = "write_zmap")]
        public static extern int WriteZmap(
            [MarshalAs(PStr)] string filename,
            int gameTypeId,
            IntPtr dataPtr,
            [MarshalAs(Usize)]
            UIntPtr dataLen);

        public static string? GetLastError()
        {
            var length = LastErrorLength();
            if (length == UIntPtr.Zero)
                return null;

            var size = UsizeToLen(length);
            var buffer = new byte[size];

            UIntPtr res;
            using (var pointer = new PinnedGCHandle(buffer))
            {
                res = LastErrorMessage(pointer, (UIntPtr)size);
            }
            if (res == UIntPtr.Zero)
                return null;
            // res = length - 1; buffer is null terminated but this is unneeded in C#
            size = UsizeToLen(res);
            return System.Text.Encoding.UTF8.GetString(buffer, 0, size);
        }

        public static void ThrowLastError()
        {
            var message = GetLastError();
            if (message == null)
                throw new InvalidOperationException("No last error");
            else
                throw new RustException(message);
        }

        public static int UsizeToLen(UIntPtr len)
        {
            var l = (int)len;
            if (l < 0)
                throw new InvalidOperationException("Buffer is too large");
            return l;
        }

        public static byte[] DecodeBytes(IntPtr ptr, UIntPtr len)
        {
            var size = UsizeToLen(len);
            var buffer = new byte[size];
            Marshal.Copy(ptr, buffer, 0, size);
            return buffer;
        }

        public static string DecodeString(IntPtr ptr, UIntPtr len)
        {
            return System.Text.Encoding.UTF8.GetString(DecodeBytes(ptr, len));
        }

        public static T Deserialize<T>(byte[] data, Mech3DotNet.Exchange.TypeConverter<T> converter)
        {
            var dc = Mech3DotNet.Exchange.Options.DefaultConverters;
            using (var r = new Mech3DotNet.Exchange.Reader(data))
            {
                var d = new Mech3DotNet.Exchange.Deserializer(r, dc);
                return d.Deserialize(converter)();
            }
        }

        public static byte[] Serialize<T>(T value, Mech3DotNet.Exchange.TypeConverter<T> converter)
        {
            var dc = Mech3DotNet.Exchange.Options.DefaultConverters;
            using (var w = new Mech3DotNet.Exchange.Writer())
            {
                var s = new Mech3DotNet.Exchange.Serializer(w, dc);
                s.Serialize(converter)(value);
                return w.GetBuffer();
            }
        }
    }
}
