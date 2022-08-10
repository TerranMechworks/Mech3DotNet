using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;
using Newtonsoft.Json;

namespace Mech3DotNet
{
    public class Messages
    {
        [JsonProperty("language_id")]
        public int languageId;
        [JsonProperty("entries")]
        public List<MessageEntry> entries;

        public Messages(int languageId, List<MessageEntry> entries)
        {
            this.languageId = languageId;
            this.entries = entries;
        }

        [JsonConstructor]
        private Messages()
        {
            this.entries = new List<MessageEntry>();
        }

        public static Messages Deserialize(string json)
        {
            return Settings.DeserializeObject<Messages>(json);
        }

        public string Serialize()
        {
            return Settings.SerializeObject(this);
        }

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
                    var json = Interop.DecodeString(pointer, length);
                    messages = Messages.Deserialize(json);
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
