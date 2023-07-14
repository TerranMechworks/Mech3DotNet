using System;
using System.IO;

namespace Mech3DotNet.Exchange
{
    /// <summary>A writer of binary exchange data. Driven by a serializer.</summary>
    public class Writer : IDisposable
    {
        private MemoryStream stream;

        public Writer()
        {
            stream = new MemoryStream();
        }

        public void Dispose() => stream.Dispose();

        public byte[] GetBuffer() => stream.GetBuffer();

        private void WriteType(TypeMap ty)
        {
            stream.Write(BitConverter.GetBytes(TypeMapExtensions.ToInt(ty)));
        }

        private void WriteUsize(ulong v)
        {
            stream.Write(BitConverter.GetBytes(v));
        }

        public void WriteI8(sbyte v)
        {
            WriteType(TypeMap.I8);
            stream.WriteByte((byte)v);
        }

        public void WriteI16(short v)
        {
            WriteType(TypeMap.I16);
            stream.Write(BitConverter.GetBytes(v));
        }

        public void WriteI32(int v)
        {
            WriteType(TypeMap.I32);
            stream.Write(BitConverter.GetBytes(v));
        }

        public void WriteU8(byte v)
        {
            WriteType(TypeMap.U8);
            stream.WriteByte(v);
        }

        public void WriteU16(ushort v)
        {
            WriteType(TypeMap.U16);
            stream.Write(BitConverter.GetBytes(v));
        }

        public void WriteU32(uint v)
        {
            WriteType(TypeMap.U32);
            stream.Write(BitConverter.GetBytes(v));
        }

        public void WriteF32(float v)
        {
            WriteType(TypeMap.F32);
            stream.Write(BitConverter.GetBytes(v));
        }

        public void WriteBool(bool v)
        {
            WriteType(v ? TypeMap.BoolTrue : TypeMap.BoolFalse);
        }

        public void WriteStr(string v)
        {
            WriteType(TypeMap.Str);
            var b = System.Text.Encoding.UTF8.GetBytes(v);
            WriteUsize((ulong)b.LongLength);
            stream.Write(b);
        }

        public void WriteBytes(byte[] v)
        {
            WriteType(TypeMap.Bytes);
            WriteUsize((ulong)v.LongLength);
            stream.Write(v);
        }

        public void WriteNone()
        {
            WriteType(TypeMap.None);
        }

        public void WriteSome()
        {
            WriteType(TypeMap.Some);
        }

        public void WriteSeqSized(ulong len)
        {
            WriteType(TypeMap.Seq);
            WriteUsize(len);
        }

        public void WriteStruct(ulong len)
        {
            WriteType(TypeMap.Struct);
            WriteUsize(len);
        }

        public void WriteEnumUnit(uint variantIndex)
        {
            WriteType(TypeMap.EnumUnit);
            stream.Write(BitConverter.GetBytes(variantIndex));
        }

        public void WriteEnumNewType(uint variantIndex)
        {
            WriteType(TypeMap.EnumNewType);
            stream.Write(BitConverter.GetBytes(variantIndex));
        }
    }
}
