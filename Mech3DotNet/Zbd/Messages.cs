using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>Message/localisation data.</summary>
    public partial class Messages
    {
        /// <summary>
        /// Read message/localisation data.
        ///
        /// Message data cannot be written again.
        /// </summary>
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

        /// <summary>
        /// Read message/localisation data, discarding the language ID.
        ///
        /// Message data cannot be written again.
        /// </summary>
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
