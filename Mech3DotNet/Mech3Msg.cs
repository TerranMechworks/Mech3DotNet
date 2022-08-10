using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class Mech3Msg
    {
        public static Messages Read(string inputPath)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            ExceptionDispatchInfo? ex = null;
            Messages? messages = null;
            var res = Interop.read_messages(inputPath, (IntPtr pointer, ulong length) =>
            {
                try
                {
                    var data = Interop.DecodeBytes(pointer, length);
                    messages = Interop.Deserialize<Messages>(data);
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
            if (messages == null)
                throw new InvalidOperationException("messages is null after reading");
            return messages;
        }

        public static Dictionary<string, string> ReadAsDict(string inputPath)
        {
            var messages = Read(inputPath);
            var dict = new Dictionary<string, string>(messages.entries.Count);
            foreach (var entry in messages.entries)
                dict.Add(entry.key, entry.value);
            return dict;
        }
    }
}
