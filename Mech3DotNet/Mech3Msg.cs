using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Types.Messages;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class Mech3Msg
    {
        public static Messages Read(string inputPath, GameType gameType)
        {
            if (inputPath == null)
                throw new ArgumentNullException(nameof(inputPath));
            var gameTypeId = Helpers.GameTypeToId(gameType);
            ExceptionDispatchInfo? ex = null;
            Messages? messages = null;
            var res = Interop.ReadMessages(inputPath, gameTypeId, (IntPtr pointer, ulong length) =>
            {
                try
                {
                    var data = Interop.DecodeBytes(pointer, length);
                    messages = Interop.Deserialize(data, Messages.Converter);
                }
                catch (Exception e)
                {
                    ex = ExceptionDispatchInfo.Capture(e);
                }
            });
            if (res != 0)
            {
                if (ex != null)
                    ex.Throw();
                else
                    Interop.ThrowLastError();
            }
            if (messages == null)
                throw new InvalidOperationException("messages is null after reading");
            return messages;
        }

        public static Dictionary<string, string> ReadAsDict(string inputPath, GameType gameType)
        {
            var messages = Read(inputPath, gameType);
            var dict = new Dictionary<string, string>(messages.entries.Count);
            foreach (var entry in messages.entries)
                dict.Add(entry.key, entry.value);
            return dict;
        }
    }
}
