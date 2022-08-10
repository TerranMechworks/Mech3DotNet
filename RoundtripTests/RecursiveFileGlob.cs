using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace RoundtripTests
{
    public class RecursiveFileGlob
    {
        private Regex regex;
        private List<string> matches;

        private RecursiveFileGlob(Regex regex)
        {
            this.regex = regex;
            matches = new List<string>();
        }

        private void Glob(string path)
        {
            foreach (var filePath in Directory.GetFiles(path))
                if (regex.IsMatch(filePath))
                    matches.Add(filePath);

            foreach (string dirPath in Directory.GetDirectories(path))
                Glob(dirPath);
        }

        public static List<string> RecursiveGlob(Regex regex, string path)
        {
            var globber = new RecursiveFileGlob(regex);
            globber.Glob(path);
            return globber.matches;
        }
    }
}
