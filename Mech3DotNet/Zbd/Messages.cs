using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// Message/localisation data.
    ///
    /// See <see cref="Read"/> for reading a message <c>.dll</c> file.
    /// </summary>
    public partial class Messages
    {
        /// <summary>
        /// Read message/localisation data from a message <c>.dll</c> file from
        /// the specified path.
        ///
        /// Message data cannot be written again.
        /// </summary>
        public static Messages Read(string path, GameType gameType)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            var gameTypeId = Helpers.GameTypeToId(gameType);
            ExceptionDispatchInfo? ex = null;
            Messages? messages = null;
            var res = Interop.ReadMessages(path, gameTypeId, (IntPtr pointer, ulong length) =>
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
        /// Read message/localisation data from a message <c>.dll</c> file from
        /// the specified path, discarding the language ID and entry IDs.
        ///
        /// Message data cannot be written again.
        /// </summary>
        public static Dictionary<string, string> ReadAsDict(string path, GameType gameType)
        {
            var messages = Read(path, gameType);
            var dict = new Dictionary<string, string>(messages.entries.Count);
            foreach (var entry in messages.entries)
                dict.Add(entry.key, entry.value);
            return dict;
        }
    }
}
