using System;
using System.Text;

namespace Mech3DotNet
{
    public class WaveException : Exception
    {
        internal WaveException(string message) : base(message) { }
    }

    public class Wave
    {
        private const short WAVE_FORMAT_PCM = 1;

        private struct Chunk
        {
            public string id;
            public int size;

            public Chunk(string id, int size)
            {
                this.id = id;
                this.size = size;
            }
        }

        public int Channels { get; private set; }
        public int Frequency { get; private set; }
        public int Samples { get; private set; }
        public float[] SampleData { get; private set; }

        private byte[] data;
        private int offset;
        private int bitsPerSample;

        public Wave(byte[] data)
        {
            this.data = data;
            this.offset = 0;
            Read();
            // don't retain a reference to the data array
            this.data = null;
        }

        private Chunk ReadChunkHeader()
        {
            var chunkId = Encoding.ASCII.GetString(data, offset, 4);
            offset += 4;
            var chunkSize = BitConverter.ToInt32(data, offset);
            offset += 4;
            return new Chunk(chunkId, chunkSize);
        }

        private void Read()
        {
            // The RIFF chunk must be first
            ReadRiffChunk();
            var fmtRead = false;
            while (offset < (data.Length - 8))
            {
                var chunk = ReadChunkHeader();
                switch (chunk.id)
                {
                    case "fmt ":
                        ReadFmtChunk(chunk.size);
                        fmtRead = true;
                        break;
                    case "data":
                        if (!fmtRead)
                            throw new WaveException($"Data chunk before format chunk at {offset}");
                        ReadData(chunk.size);
                        return;
                    default:
                        // skip unknown chunks
                        offset += chunk.size;
                        // if the chunk is an odd size, it has a pad byte
                        if ((chunk.size & 1) == 1)
                        {
                            offset += 1;
                        }
                        break;
                }
            }
            if (!fmtRead)
                throw new WaveException($"Format chunk not found");
            throw new WaveException($"Data chunk not found");
        }

        private void ReadRiffChunk()
        {
            var chunkId = Encoding.ASCII.GetString(data, offset, 4);
            if (chunkId != "RIFF")
                throw new WaveException($"Expected chunk 'RIFF', but was '{chunkId}' at {offset}");
            offset += 4;
            // TODO: validate this against length of data?
            var _chunkSize = BitConverter.ToInt32(data, offset);
            offset += 4;
            var format = Encoding.ASCII.GetString(data, offset, 4);
            if (format != "WAVE")
                throw new WaveException($"Expected format 'WAVE', but was '{format}' at {offset}");
            offset += 4;
        }

        private void ReadFmtChunk(int chunkSize)
        {
            var formatTag = BitConverter.ToInt16(data, offset);
            if (formatTag != WAVE_FORMAT_PCM)
                throw new WaveException($"Expected PCM ({WAVE_FORMAT_PCM}), but was {formatTag} at {offset}");
            // this is only valid for PCM files
            if (chunkSize != 16)
                throw new WaveException($"Expected format chunk size 16, but was {chunkSize} at {offset - 4}");
            offset += 2;
            Channels = BitConverter.ToInt16(data, offset);
            offset += 2;
            // aka. SamplesPerSec, sample rate, sampling rate. Unity calls this frequency
            Frequency = BitConverter.ToInt32(data, offset);
            offset += 4;
            // PCM: Channels * bitsPerSecond * (bitsPerSample / 8)
            var _avgBytesPerSec = BitConverter.ToInt32(data, offset);
            offset += 4;
            // PCM: Channels * (bitsPerSample / 8)
            var _blockAlign = BitConverter.ToInt16(data, offset);
            offset += 2;
            // aka. sample size
            bitsPerSample = BitConverter.ToInt16(data, offset);
            offset += 2;

        }

        private void ReadData(int chunkSize)
        {
            // It's possible to have bps values not integer multiples of 8,
            // e.g. 12 bits is specifically mentioned in the spec. This logic
            // rounds up to the nearest 8 bits; however scaling non-integer
            // multiples isn't implemented, and will throw an exception.
            var bytesPerSample = (bitsPerSample + 7) / 8;
            // Unity seems to want samples, i.e. channels are left interleaved.
            var samples = chunkSize / bytesPerSample;
            switch (bitsPerSample)
            {
                case 8:
                    ReadSamples8Bit(samples);
                    break;
                case 16:
                    ReadSamples16Bit(samples);
                    break;
                default:
                    throw new WaveException($"Unsupported bit depth {bitsPerSample}");
            }
        }

        private void ReadSamples8Bit(int samples)
        {
            Samples = samples;
            SampleData = new float[samples];
            // 8 bit WAV files are unsigned, from 0 to 255 (mid is 128).
            // We want to shift the values so that the midpoint is 0, which makes
            // the minimum -128 (sbyte.MinValue) and maximum 127 (sbyte.MaxValue).
            // To avoid clipping on the minimum value, divide by 128.
            var maxValue = ((float)sbyte.MaxValue) + 1f;
            for (var i = 0; i < samples; i++, offset++)
            {
                SampleData[i] = (((float)data[offset]) - maxValue) / maxValue;
            }
        }

        private void ReadSamples16Bit(int samples)
        {
            Samples = samples;
            SampleData = new float[samples];
            // 16 bit WAV files are signed, from -32768 to 32767 (mid is 0).
            // This means no shifting of the values is needed (already in range
            // of short.MinValue and short.MaxValue).
            // To avoid clipping on the minimum value, divide by 32768.
            var maxValue = ((float)short.MaxValue) + 1f;
            for (var i = 0; i < samples; i++, offset += 2)
            {
                SampleData[i] = ((float)BitConverter.ToInt16(data, offset)) / maxValue;
            }
        }
    }
}
