using System;
using System.IO;

namespace Mech3DotNet.Exchange
{
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

        private void WriteStringRaw(string s)
        {
            var v = System.Text.Encoding.UTF8.GetBytes(s);
            WriteUsize((ulong)v.LongLength);
            stream.Write(v);
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
            WriteStringRaw(v);
        }

        public void WriteBytes(byte[] v)
        {
            WriteType(TypeMap.Bytes);
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

        public void WriteStruct(string name, ulong len)
        {
            WriteType(TypeMap.Struct);
            WriteStringRaw(name);
            WriteUsize(len);
        }

        private void WriteEnumVariant(uint variantIndex)
        {
            stream.Write(BitConverter.GetBytes(variantIndex));
        }

        public void WriteEnumUnit(string name, uint variantIndex)
        {
            WriteType(TypeMap.EnumUnit);
            WriteStringRaw(name);
            WriteEnumVariant(variantIndex);
        }

        public void WriteEnumNewType(string name, uint variantIndex)
        {
            WriteType(TypeMap.EnumNewType);
            WriteStringRaw(name);
            WriteEnumVariant(variantIndex);
        }
    }
}
