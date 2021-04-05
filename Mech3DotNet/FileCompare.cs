using System.IO;

namespace Mech3DotNet
{
    public static class FileCompare
    {
        const int CHUNK_SIZE = 4 * 1024;

        public static string CompareFiles(string srcPath, string dstPath)
        {
            return CompareFiles(srcPath, dstPath, CHUNK_SIZE);
        }

        public static string CompareFiles(string srcPath, string dstPath, int chunkSize)
        {
            using (var srcStream = File.OpenRead(srcPath))
            using (var dstStream = File.OpenRead(dstPath))
            {
                if (srcStream.Length != dstStream.Length)
                    return $"Length mismatch: {srcStream.Length} != {dstStream.Length}";

                var srcBuf = new byte[chunkSize];
                var dstBuf = new byte[chunkSize];
                int totalRead = 0;

                while (true)
                {
                    var srcRead = srcStream.Read(srcBuf, 0, CHUNK_SIZE);
                    var dstRead = dstStream.Read(dstBuf, 0, CHUNK_SIZE);

                    if (srcRead != dstRead)
                        throw new IOException($"Read mismatch: {srcRead} != {dstRead}");

                    for (var i = 0; i < srcRead; i++)
                        if (srcBuf[i] != dstBuf[i])
                            return $"Byte mismatch at {totalRead + i}";

                    totalRead += srcRead;
                    if (srcRead < CHUNK_SIZE)
                        break;
                }
            }
            return null;
        }
    }
}
