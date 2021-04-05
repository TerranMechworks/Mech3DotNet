using System;
using System.IO;

namespace Mech3DotNet
{
    public class TemporaryFile : IDisposable
    {
        private string filePath;

        public TemporaryFile()
        {
            filePath = Path.GetTempFileName();
        }

        public TemporaryFile(byte[] data)
        {
            filePath = Path.GetTempFileName();
            File.WriteAllBytes(filePath, data);
        }

        public TemporaryFile(string data)
        {
            filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, data, System.Text.Encoding.UTF8);
        }

        public static implicit operator string(TemporaryFile tempFile)
        {
            return tempFile.filePath;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && filePath != null)
            {
                File.Delete(filePath);
                filePath = null;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TemporaryFile()
        {
            this.Dispose(false);
        }
    }
}
