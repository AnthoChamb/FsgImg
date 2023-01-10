using System;
using System.Buffers.Binary;

namespace FsgImg.IO
{
    public static class EndianBinaryPrimitives
    {
        public static short ReadInt16(ReadOnlySpan<byte> source, bool isLittleEndian)
        {
            return isLittleEndian ? BinaryPrimitives.ReadInt16LittleEndian(source) : BinaryPrimitives.ReadInt16BigEndian(source);
        }

        public static ushort ReadUInt16(ReadOnlySpan<byte> source, bool isLittleEndian)
        {
            return isLittleEndian ? BinaryPrimitives.ReadUInt16LittleEndian(source) : BinaryPrimitives.ReadUInt16BigEndian(source);
        }

        public static int ReadInt32(ReadOnlySpan<byte> source, bool isLittleEndian)
        {
            return isLittleEndian ? BinaryPrimitives.ReadInt32LittleEndian(source) : BinaryPrimitives.ReadInt32BigEndian(source);
        }

        public static uint ReadUInt32(ReadOnlySpan<byte> source, bool isLittleEndian)
        {
            return isLittleEndian ? BinaryPrimitives.ReadUInt32LittleEndian(source) : BinaryPrimitives.ReadUInt32BigEndian(source);
        }

        public static long ReadInt64(ReadOnlySpan<byte> source, bool isLittleEndian)
        {
            return isLittleEndian ? BinaryPrimitives.ReadInt64LittleEndian(source) : BinaryPrimitives.ReadInt64BigEndian(source);
        }

        public static ulong ReadUInt64(ReadOnlySpan<byte> source, bool isLittleEndian)
        {
            return isLittleEndian ? BinaryPrimitives.ReadUInt64LittleEndian(source) : BinaryPrimitives.ReadUInt64BigEndian(source);
        }

        public static void WriteInt16(Span<byte> destination, short value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                BinaryPrimitives.WriteInt16LittleEndian(destination, value);
            }
            else
            {
                BinaryPrimitives.WriteInt16BigEndian(destination, value);
            }
        }

        public static void WriteUInt16(Span<byte> destination, ushort value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                BinaryPrimitives.WriteUInt16LittleEndian(destination, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian(destination, value);
            }
        }

        public static void WriteInt32(Span<byte> destination, int value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                BinaryPrimitives.WriteInt32LittleEndian(destination, value);
            }
            else
            {
                BinaryPrimitives.WriteInt32BigEndian(destination, value);
            }
        }

        public static void WriteUInt32(Span<byte> destination, uint value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(destination, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian(destination, value);
            }
        }

        public static void WriteInt64(Span<byte> destination, long value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                BinaryPrimitives.WriteInt64LittleEndian(destination, value);
            }
            else
            {
                BinaryPrimitives.WriteInt64BigEndian(destination, value);
            }
        }

        public static void WriteUInt64(Span<byte> destination, ulong value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(destination, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt64BigEndian(destination, value);
            }
        }
    }
}
