using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public class ReaderData
    {
        private static readonly byte[] NULL_LITERAL = System.Text.Encoding.ASCII.GetBytes("null");

        public JsonNode? root;

        public ReaderData(JsonNode? root)
        {
            this.root = root;
        }

        private static bool DataIsNullLiteral(byte[] data)
        {
            if (data.Length != NULL_LITERAL.Length)
                return false;
            for (var i = 0; i < NULL_LITERAL.Length; i++)
            {
                if (data[i] != NULL_LITERAL[i])
                    return false;
            }
            return true;
        }

        public static ReaderData Deserialize(byte[] data)
        {
            // some reader files (c2/mobilerepair.zrd) contain empty arrays,
            // and mech3ax deserializes this as null, which JsonNode.Parse
            // can't handle
            if (DataIsNullLiteral(data))
                return new ReaderData(null);
            var root = JsonNode.Parse(data);
            // since we couldn't disambiguate this from the null case, this is
            // not allowed to happen
            if (root is null)
                throw new InvalidOperationException("Parsed JsonNode was null");
            return new ReaderData(root);
        }

        public byte[] Serialize()
        {
            if (root is null)
                return NULL_LITERAL;

            using var stream = new System.IO.MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                root.WriteTo(writer);
            }
            return stream.ToArray();
        }

        public static Query operator /(ReaderData reader, IQueryOperation op)
        {
            if (reader.root == null)
                throw new ArgumentNullException("root");
            var query = new Query(reader.root);
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
    }
}
