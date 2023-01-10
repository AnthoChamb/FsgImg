using System.Buffers.Binary;
using System.IO;

namespace FsgImg.IO.Extensions
{
    public static class EndianBinaryReaderExtensions
    {
        public static short ReadInt16(this BinaryReader reader, bool isLittleEndian)
        {
            return EndianBinaryPrimitives.ReadInt16(reader.ReadBytes(sizeof(short)), isLittleEndian);
        }

        public static short ReadInt16BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadInt16BigEndian(reader.ReadBytes(sizeof(short)));
        }

        public static short ReadInt16LittleEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadInt16LittleEndian(reader.ReadBytes(sizeof(short)));
        }

        public static ushort ReadUInt16(this BinaryReader reader, bool isLittleEndian)
        {
            return EndianBinaryPrimitives.ReadUInt16(reader.ReadBytes(sizeof(ushort)), isLittleEndian);
        }

        public static ushort ReadUInt16BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(sizeof(ushort)));
        }

        public static ushort ReadUInt16LittleEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt16LittleEndian(reader.ReadBytes(sizeof(ushort)));
        }

        public static int ReadInt32(this BinaryReader reader, bool isLittleEndian)
        {
            return EndianBinaryPrimitives.ReadInt32(reader.ReadBytes(sizeof(int)), isLittleEndian);
        }

        public static int ReadInt32BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(sizeof(int)));
        }

        public static int ReadInt32LittleEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadInt32LittleEndian(reader.ReadBytes(sizeof(int)));
        }

        public static uint ReadUInt32(this BinaryReader reader, bool isLittleEndian)
        {
            return EndianBinaryPrimitives.ReadUInt32(reader.ReadBytes(sizeof(uint)), isLittleEndian);
        }

        public static uint ReadUInt32BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt32BigEndian(reader.ReadBytes(sizeof(uint)));
        }

        public static uint ReadUInt32LittleEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt32LittleEndian(reader.ReadBytes(sizeof(uint)));
        }

        public static long ReadInt64(this BinaryReader reader, bool isLittleEndian)
        {
            return EndianBinaryPrimitives.ReadInt64(reader.ReadBytes(sizeof(long)), isLittleEndian);
        }

        public static long ReadInt64BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadInt64BigEndian(reader.ReadBytes(sizeof(long)));
        }

        public static long ReadInt64LittleEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadInt64LittleEndian(reader.ReadBytes(sizeof(long)));
        }

        public static ulong ReadUInt64(this BinaryReader reader, bool isLittleEndian)
        {
            return EndianBinaryPrimitives.ReadUInt64(reader.ReadBytes(sizeof(ulong)), isLittleEndian);
        }

        public static ulong ReadUInt64BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt64BigEndian(reader.ReadBytes(sizeof(ulong)));
        }

        public static ulong ReadUInt64LittleEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt64LittleEndian(reader.ReadBytes(sizeof(ulong)));
        }
    }
}
