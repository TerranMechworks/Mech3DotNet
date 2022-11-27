using System;
using System.IO;

namespace Mech3DotNet.Exchange
{
    public enum EnumType
    {
        Unit,
        NewType,
    }

    public class Reader : IDisposable
    {
        private MemoryStream stream;

        public Reader(byte[] bytes)
        {
            stream = new MemoryStream(bytes, false);
        }

        public void Dispose() => stream.Dispose();

        private TypeMap ReadType()
        {
            var buf = new byte[4];
            stream.Read(buf);
            var ty = BitConverter.ToInt32(buf);
            return TypeMapExtensions.FromInt(ty);
        }

        private ulong ReadUsize()
        {
            var buf = new byte[8];
            stream.Read(buf);
            return BitConverter.ToUInt64(buf);
        }

        private string ReadStringRaw()
        {
            var len = ReadUsize();
            var buf = new byte[len];
            stream.Read(buf);
            return System.Text.Encoding.UTF8.GetString(buf);
        }

        private void ExpectType(TypeMap expected)
        {
            var actual = ReadType();
            if (actual != expected)
                throw new ArgumentException();
        }

        public sbyte ReadI8()
        {
            ExpectType(TypeMap.I8);
            var buf = new byte[1];
            stream.Read(buf);
            return (sbyte)buf[0];
        }

        public short ReadI16()
        {
            ExpectType(TypeMap.I16);
            var buf = new byte[2];
            stream.Read(buf);
            return BitConverter.ToInt16(buf);
        }

        public int ReadI32()
        {
            ExpectType(TypeMap.I32);
            var buf = new byte[4];
            stream.Read(buf);
            return BitConverter.ToInt32(buf);
        }

        public byte ReadU8()
        {
            ExpectType(TypeMap.U8);
            var buf = new byte[1];
            stream.Read(buf);
            return buf[0];
        }

        public ushort ReadU16()
        {
            ExpectType(TypeMap.U16);
            var buf = new byte[2];
            stream.Read(buf);
            return BitConverter.ToUInt16(buf);
        }

        public uint ReadU32()
        {
            ExpectType(TypeMap.U32);
            var buf = new byte[4];
            stream.Read(buf);
            return BitConverter.ToUInt32(buf);
        }

        public float ReadF32()
        {
            ExpectType(TypeMap.F32);
            var buf = new byte[4];
            stream.Read(buf);
            return BitConverter.ToSingle(buf);
        }

        public bool ReadBool() => ReadType() switch
        {
            TypeMap.BoolTrue => true,
            TypeMap.BoolFalse => false,
            _ => throw new ArgumentException(),
        };

        public string ReadStr()
        {
            ExpectType(TypeMap.Str);
            return ReadStringRaw();
        }

        public byte[] ReadBytes()
        {
            ExpectType(TypeMap.Bytes);
            var len = ReadUsize();
            var buf = new byte[len];
            stream.Read(buf);
            return buf;
        }

        public bool ReadOption() => ReadType() switch
        {
            TypeMap.Some => true,
            TypeMap.None => false,
            _ => throw new ArgumentException(),
        };

        public ulong ReadSeqSized()
        {
            ExpectType(TypeMap.Seq);
            return ReadUsize();
        }

        private void ExpectStructName(string name)
        {
            var actual = ReadStringRaw();
            if (name != actual)
            {
                throw new ArgumentException();
            }
        }

        public ulong ReadStruct(string name)
        {
            ExpectType(TypeMap.Struct);
            ExpectStructName(name);
            return ReadUsize();
        }

        private uint ReadEnumVariant()
        {
            var buf = new byte[4];
            stream.Read(buf);
            return BitConverter.ToUInt32(buf);
        }

        public (EnumType, uint) ReadEnum(string name)
        {
            var enumType = ReadType() switch
            {
                TypeMap.EnumUnit => EnumType.Unit,
                TypeMap.EnumNewType => EnumType.NewType,
                _ => throw new ArgumentException(),
            };
            ExpectStructName(name);
            var variantIndex = ReadEnumVariant();
            return (enumType, variantIndex);
        }
    }
}
