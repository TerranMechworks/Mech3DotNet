using System;
using System.Collections;
using System.Collections.Generic;

namespace Mech3DotNet
{
    public class QueryPath : IEnumerator<QueryPath.Segment>, IEnumerable<QueryPath.Segment>
    {
        public class Segment
        {
            private string key;
            private int index;

            private Segment(string key, int index)
            {
                this.key = key;
                this.index = index;
            }

            public static Segment K(string key) { return new Segment(key, 0); }
            public static Segment I(int index) { return new Segment(null, index); }

            public bool IsKey { get { return key != null; } }
            public bool IsIndex { get { return key == null; } }
            public string Key { get { return key; } }
            public int Index { get { return index; } }

            public override string ToString()
            {
                if (IsKey)
                    return key.ToString();
                return index.ToString();
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Segment);
            }

            public bool Equals(Segment other)
            {
                if (ReferenceEquals(other, null))
                    return false;
                if (ReferenceEquals(this, other))
                    return true;
                if (IsKey)
                {
                    if (other.IsIndex)
                        return false;
                    return key == other.key;
                }
                else
                {
                    if (other.IsKey)
                        return false;
                    return index == other.index;
                }
            }
        }

        private string[] segments;
        private Queue<string> remaining;
        private List<string> processed;
        private Segment current;

        public QueryPath(string path)
        {
            if (!path.StartsWith("/"))
                throw new ArgumentException($"Path '{path}' is not rooted");
            var rel = path.Substring(1);
            if (rel.Length == 0)
                segments = new string[0];
            else
                segments = rel.Split('/');
            foreach (var segment in segments)
            {
                if (segment.Length == 0)
                    throw new ArgumentException($"Path '{path}' contains empty segments");
            }
            Reset();
        }

        public string Processed { get => string.Join("/", processed.ToArray()); }

        private static Segment Parse(string segment)
        {
            // quoted number; don't parse
            if (segment.StartsWith("`"))
                return Segment.K(segment.Substring(1));
            int value;
            if (int.TryParse(segment, out value))
                return Segment.I(value);
            return Segment.K(segment);
        }

        public Segment Current { get => current; }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            string segment;
            try
            {
                segment = remaining.Dequeue();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            processed.Add(segment);
            current = Parse(segment);
            return true;
        }

        public void Reset()
        {
            remaining = new Queue<string>(segments);
            processed = new List<string>();
            processed.Add(""); // when joined, start with '/'
            current = null;
        }

        public IEnumerator<Segment> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
