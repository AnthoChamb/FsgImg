using System.Buffers.Binary;
using System.IO;

namespace FsgImg.IO.Extensions
{
    public static class EndianBinaryWriterExtensions
    {
        public static void WriteInt16(this BinaryWriter writer, short value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                writer.WriteInt16LittleEndian(value);
            }
            else
            {
                writer.WriteInt16BigEndian(value);
            }
        }

        public static void WriteInt16BigEndian(this BinaryWriter writer, short value)
        {
            var buffer = new byte[sizeof(short)];
            BinaryPrimitives.WriteInt16BigEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteInt16LittleEndian(this BinaryWriter writer, short value)
        {
            var buffer = new byte[sizeof(short)];
            BinaryPrimitives.WriteInt16LittleEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteUInt16(this BinaryWriter writer, ushort value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                writer.WriteUInt16LittleEndian(value);
            }
            else
            {
                writer.WriteUInt16BigEndian(value);
            }
        }

        public static void WriteUInt16BigEndian(this BinaryWriter writer, ushort value)
        {
            var buffer = new byte[sizeof(ushort)];
            BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteUInt16LittleEndian(this BinaryWriter writer, ushort value)
        {
            var buffer = new byte[sizeof(ushort)];
            BinaryPrimitives.WriteUInt16LittleEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteInt32(this BinaryWriter writer, int value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                writer.WriteInt32LittleEndian(value);
            }
            else
            {
                writer.WriteInt32BigEndian(value);
            }
        }

        public static void WriteInt32BigEndian(this BinaryWriter writer, int value)
        {
            var buffer = new byte[sizeof(int)];
            BinaryPrimitives.WriteInt32BigEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteInt32LittleEndian(this BinaryWriter writer, int value)
        {
            var buffer = new byte[sizeof(int)];
            BinaryPrimitives.WriteInt32LittleEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteUInt32(this BinaryWriter writer, uint value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                writer.WriteUInt32LittleEndian(value);
            }
            else
            {
                writer.WriteUInt32BigEndian(value);
            }
        }

        public static void WriteUInt32BigEndian(this BinaryWriter writer, uint value)
        {
            var buffer = new byte[sizeof(uint)];
            BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteUInt32LittleEndian(this BinaryWriter writer, uint value)
        {
            var buffer = new byte[sizeof(uint)];
            BinaryPrimitives.WriteUInt32LittleEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteInt64(this BinaryWriter writer, long value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                writer.WriteInt64LittleEndian(value);
            }
            else
            {
                writer.WriteInt64BigEndian(value);
            }
        }

        public static void WriteInt64BigEndian(this BinaryWriter writer, long value)
        {
            var buffer = new byte[sizeof(long)];
            BinaryPrimitives.WriteInt64BigEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteInt64LittleEndian(this BinaryWriter writer, long value)
        {
            var buffer = new byte[sizeof(long)];
            BinaryPrimitives.WriteInt64LittleEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteUInt64(this BinaryWriter writer, ulong value, bool isLittleEndian)
        {
            if (isLittleEndian)
            {
                writer.WriteUInt64LittleEndian(value);
            }
            else
            {
                writer.WriteUInt64BigEndian(value);
            }
        }

        public static void WriteUInt64BigEndian(this BinaryWriter writer, ulong value)
        {
            var buffer = new byte[sizeof(ulong)];
            BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
            writer.Write(buffer);
        }

        public static void WriteUInt64LittleEndian(this BinaryWriter writer, ulong value)
        {
            var buffer = new byte[sizeof(ulong)];
            BinaryPrimitives.WriteUInt64LittleEndian(buffer, value);
            writer.Write(buffer);
        }
    }
}
