using System;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Unsafe
{
    /// <summary>
    /// Helpers for interfacing with the raw mech3ax library bindings.
    /// </summary>
    internal static class Helpers
    {
        public delegate int ReadArchiveFn(string filename, int gameTypeId, Interop.NameDataCb callback);
        public delegate void ReadArchiveCb(string filename, byte[] data);

        public delegate int WriteArchiveFn(string filename, int gameTypeId, IntPtr manifestPtr, UIntPtr manifestLen, Interop.NameBufferCb callback);
        public delegate byte[] WriteArchiveCb(string filename);

        public delegate int ReadDataFn(string filename, int gameTypeId, Interop.DataCb callback);
        public delegate int WriteDataFn(string filename, int gameTypeId, IntPtr dataPtr, UIntPtr dataLen);

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

        public static byte[] ReadArchive(string path, GameType gameType, string manifestName, ReadArchiveFn readFunction, ReadArchiveCb readCallback)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            var gameTypeId = GameTypeToId(gameType);
            ExceptionDispatchInfo? ex = null;
            byte[]? manifest = null;
            var res = readFunction(path, gameTypeId, (IntPtr namePtr, UIntPtr nameLen, IntPtr dataPtr, UIntPtr dataLen) =>
            {
                try
                {
                    var name = Interop.DecodeString(namePtr, nameLen);
                    var data = Interop.DecodeBytes(dataPtr, dataLen);
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

        public static void WriteArchive(string path, GameType gameType, byte[] manifest_data, WriteArchiveFn writeFunction, WriteArchiveCb writeCallback)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            var gameTypeId = GameTypeToId(gameType);
            var manifestLen = (UIntPtr)manifest_data.LongLength;
            ExceptionDispatchInfo? ex = null;
            int res;
            using (var manifestPtr = new PinnedGCHandle(manifest_data))
            {
                res = writeFunction(path, gameTypeId, manifestPtr, manifestLen, (IntPtr namePtr, UIntPtr nameLen, IntPtr bufPtr) =>
                {
                    try
                    {
                        var name = Interop.DecodeString(namePtr, nameLen);
                        var data = writeCallback(name);
                        var dataLen = (UIntPtr)data.LongLength;
                        using (var dataPtr = new PinnedGCHandle(data))
                        {
                            Interop.BufferSetData(bufPtr, dataPtr, dataLen);
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

        public static T ReadData<T>(string path, GameType gameType, ReadDataFn readFunction, TypeConverter<T> converter)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            var gameTypeId = GameTypeToId(gameType);
            ExceptionDispatchInfo? ex = null;
            byte[]? data = null;
            var res = readFunction(path, gameTypeId, (IntPtr dataPtr, UIntPtr dataLen) =>
            {
                try
                {
                    data = Interop.DecodeBytes(dataPtr, dataLen);
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
            return Interop.Deserialize(data, converter);
        }

        public static void WriteData<T>(string path, GameType gameType, WriteDataFn writeFunction, T value, TypeConverter<T> converter)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            var gameTypeId = GameTypeToId(gameType);
            var data = Interop.Serialize(value, converter);
            var dataLen = (UIntPtr)data.LongLength;
            int res;
            using (var dataPtr = new PinnedGCHandle(data))
            {
                res = writeFunction(path, gameTypeId, dataPtr, dataLen);
            }
            if (res != 0)
                Interop.ThrowLastError();
        }
    }
}
