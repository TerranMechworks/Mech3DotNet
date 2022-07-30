using System;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class Helpers
    {
        public delegate int ReadArchiveFn(string filename, bool is_pm, Interop.NameDataCb callback);
        public delegate void ReadArchiveCb(string filename, byte[] data);

        public delegate int WriteArchiveFn(string filename, bool is_pm, IntPtr manifest_ptr, ulong manifest_len, Interop.NameBufferCb callback);
        public delegate byte[] WriteArchiveCb(string filename);

        public delegate int ReadDataFn(string filename, bool is_pm, Interop.DataCb callback);
        public delegate int WriteDataFn(string filename, bool is_pm, IntPtr pointer, ulong length);

        public static byte[] ReadArchiveRaw(string inputPath, bool isPM, ReadArchiveFn readFunction, ReadArchiveCb readCallback)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            Exception? ex = null;
            byte[]? manifest = null;
            var res = readFunction(inputPath, isPM, (IntPtr namePointer, ulong nameLength, IntPtr dataPointer, ulong dataLength) =>
            {
                try
                {
                    var name = Interop.DecodeString(namePointer, nameLength);
                    var data = Interop.DecodeBytes(dataPointer, dataLength);
                    if (name == "manifest.json")
                        manifest = data;
                    else
                        readCallback(name, data);
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
            if (manifest == null)
                throw new InvalidOperationException("manifest is null after reading");
            return manifest;
        }

        public static void WriteArchiveRaw(string outputPath, bool isPM, byte[] manifest, WriteArchiveFn writeFunction, WriteArchiveCb writeCallback)
        {
            if (outputPath == null)
                throw new ArgumentNullException(nameof(outputPath));
            var manifestLength = (ulong)manifest.Length;
            Exception? ex = null;
            int res;
            using (var manifestPointer = new PinnedGCHandle(manifest))
            {
                res = writeFunction(outputPath, isPM, manifestPointer, manifestLength, (IntPtr namePointer, ulong nameLength, IntPtr buffer) =>
                {
                    try
                    {
                        var name = Interop.DecodeString(namePointer, nameLength);
                        var data = writeCallback(name);
                        var dataLength = (ulong)data.Length;
                        using (var dataPointer = new PinnedGCHandle(data))
                        {
                            Interop.buffer_set_data(buffer, dataPointer, dataLength);
                        }
                        return 0;
                    }
                    catch (Exception e)
                    {
                        ex = e;
                        return -1;
                    }
                });
            }
            if (res != 0)
            {
                if (ex != null)
                    throw ex;
                else
                    Interop.ThrowLastError();
            }
        }

        public static byte[] ReadDataRaw(string inputPath, bool isPM, ReadDataFn readFunction)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            Exception? ex = null;
            byte[]? data = null;
            var res = readFunction(inputPath, isPM, (IntPtr pointer, ulong length) =>
            {
                try
                {
                    data = Interop.DecodeBytes(pointer, length);
                }
                catch (Exception e)
                {
                    ex = e;
                }
            });
            if (ex != null)
                throw ex;
            if (res != 0)
                Interop.ThrowLastError();
            if (data == null)
                throw new InvalidOperationException("data is null after reading");
            return data;
        }

        public static T ReadData<T>(string inputPath, bool isPM, ReadDataFn readFunction)
        {
            var data = ReadDataRaw(inputPath, isPM, readFunction);
            var json = Interop.GetString(data);
            return Settings.DeserializeObject<T>(json);
        }

        public static void WriteDataRaw(string outputPath, bool isPM, WriteDataFn writeFunction, byte[] data)
        {
            if (outputPath == null)
                throw new ArgumentNullException(nameof(outputPath));
            var length = (ulong)data.Length;
            int res;
            using (var pointer = new PinnedGCHandle(data))
            {
                res = writeFunction(outputPath, isPM, pointer, length);
            }
            if (res != 0)
                Interop.ThrowLastError();
        }

        public static void WriteData(string outputPath, bool isPM, WriteDataFn writeFunction, object value)
        {
            var json = Settings.SerializeObject(value);
            var data = Interop.GetBytes(json);
            WriteDataRaw(outputPath, isPM, writeFunction, data);
        }
    }
}
