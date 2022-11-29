using System;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Exchange;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class Helpers
    {
        public delegate int ReadArchiveFn(string filename, int gameTypeId, Interop.NameDataCb callback);
        public delegate void ReadArchiveCb(string filename, byte[] data);

        public delegate int WriteArchiveFn(string filename, int gameTypeId, IntPtr manifest_ptr, ulong manifest_len, Interop.NameBufferCb callback);
        public delegate byte[] WriteArchiveCb(string filename);

        public delegate int ReadDataFn(string filename, int gameTypeId, Interop.DataCb callback);
        public delegate int WriteDataFn(string filename, int gameTypeId, IntPtr pointer, ulong length);

        internal static int GameTypeToId(GameType gameType) => gameType switch
        {
            GameType.MW => 0,
            GameType.PM => 1,
            GameType.RC => 2,
            GameType.CS => 3,
            _ => throw new System.ArgumentOutOfRangeException(nameof(GameType)),
        };

        internal const GameType IGNORED = GameType.MW;
        internal const string MANIFEST = "manifest.bin";

        public static byte[] ReadArchiveRaw(string inputPath, GameType gameType, string manifestName, ReadArchiveFn readFunction, ReadArchiveCb readCallback)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            var gameTypeId = GameTypeToId(gameType);
            ExceptionDispatchInfo? ex = null;
            byte[]? manifest = null;
            var res = readFunction(inputPath, gameTypeId, (IntPtr namePointer, ulong nameLength, IntPtr dataPointer, ulong dataLength) =>
            {
                try
                {
                    var name = Interop.DecodeString(namePointer, nameLength);
                    var data = Interop.DecodeBytes(dataPointer, dataLength);
                    if (name == manifestName)
                        manifest = data;
                    else
                        readCallback(name, data);
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
            if (manifest == null)
                throw new InvalidOperationException("manifest is null after reading");
            return manifest;
        }

        public static void WriteArchiveRaw(string outputPath, GameType gameType, byte[] manifest, WriteArchiveFn writeFunction, WriteArchiveCb writeCallback)
        {
            if (outputPath == null)
                throw new ArgumentNullException(nameof(outputPath));
            var gameTypeId = GameTypeToId(gameType);
            var manifestLength = (ulong)manifest.Length;
            ExceptionDispatchInfo? ex = null;
            int res;
            using (var manifestPointer = new PinnedGCHandle(manifest))
            {
                res = writeFunction(outputPath, gameTypeId, manifestPointer, manifestLength, (IntPtr namePointer, ulong nameLength, IntPtr buffer) =>
                {
                    try
                    {
                        var name = Interop.DecodeString(namePointer, nameLength);
                        var data = writeCallback(name);
                        var dataLength = (ulong)data.Length;
                        using (var dataPointer = new PinnedGCHandle(data))
                        {
                            Interop.BufferSetData(buffer, dataPointer, dataLength);
                        }
                        return 0;
                    }
                    catch (Exception e)
                    {
                        ex = ExceptionDispatchInfo.Capture(e);
                        return -1;
                    }
                });
            }
            if (res != 0)
            {
                if (ex != null)
                    ex.Throw();
                else
                    Interop.ThrowLastError();
            }
        }

        public static byte[] ReadDataRaw(string inputPath, GameType gameType, ReadDataFn readFunction)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            var gameTypeId = GameTypeToId(gameType);
            ExceptionDispatchInfo? ex = null;
            byte[]? data = null;
            var res = readFunction(inputPath, gameTypeId, (IntPtr pointer, ulong length) =>
            {
                try
                {
                    data = Interop.DecodeBytes(pointer, length);
                }
                catch (Exception e)
                {
                    ex = ExceptionDispatchInfo.Capture(e);
                }
            });
            if (ex != null)
                ex.Throw();
            if (res != 0)
                Interop.ThrowLastError();
            if (data == null)
                throw new InvalidOperationException("data is null after reading");
            return data;
        }

        public static T ReadData<T>(string inputPath, GameType gameType, ReadDataFn readFunction, TypeConverter<T> converter)
        {
            var data = ReadDataRaw(inputPath, gameType, readFunction);
            return Interop.Deserialize(data, converter);
        }

        public static void WriteDataRaw(string outputPath, GameType gameType, WriteDataFn writeFunction, byte[] data)
        {
            if (outputPath == null)
                throw new ArgumentNullException(nameof(outputPath));
            var gameTypeId = GameTypeToId(gameType);
            var length = (ulong)data.Length;
            int res;
            using (var pointer = new PinnedGCHandle(data))
            {
                res = writeFunction(outputPath, gameTypeId, pointer, length);
            }
            if (res != 0)
                Interop.ThrowLastError();
        }

        public static void WriteData<T>(string outputPath, GameType gameType, WriteDataFn writeFunction, T value, TypeConverter<T> converter)
        {
            var data = Interop.Serialize(value, converter);
            WriteDataRaw(outputPath, gameType, writeFunction, data);
        }
    }
}
