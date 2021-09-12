using Newtonsoft.Json.Linq;
using System;

namespace Mech3DotNet.Reader
{
    public class ReaderData
    {
        public JToken root;
        private ReaderDeserializer deserializer;

        public ReaderData(JToken root)
        {
            this.root = root;
            this.deserializer = new ReaderDeserializer();
        }

        public static Query operator /(ReaderData reader, IQueryOperation op)
        {
            var query = new Query(reader.root, reader.deserializer);
            return query / op;
        }

        public static Query operator /(ReaderData reader, int index)
        {
            return reader / new FindByIndex(index);
        }

        public static Query operator /(ReaderData reader, string key)
        {
            return reader / new FindByKey(key);
        }

        /// <summary>Deserialize reader data from JSON</summary>
        public static ReaderData Deserialize(string json)
        {
            var root = Settings.DeserializeObject<JArray>(json);
            // some reader files (c2/mobilerepair.zrd) contain empty arrays,
            // and mech3ax deserializes this as null
            if (root == null)
                return new ReaderData(null);
            // we strip the first array, since all readers have this
            if (root.Count != 1)
                throw new InvalidRootException();
            return new ReaderData(root.First);
        }

        /// <summary>Serialize reader data to JSON</summary>
        public string Serialize()
        {
            // some reader files (c2/mobilerepair.zrd) contain empty arrays,
            // and mech3ax deserializes this as null
            if (this.root == null)
                return Settings.SerializeObject(null);
            // since we strip the first array on load, add it back
            var new_root = new JArray();
            new_root.Add(root);
            return Settings.SerializeObject(new_root);
        }

        public override string ToString()
        {
            return root.ToString();
        }
    }
}
