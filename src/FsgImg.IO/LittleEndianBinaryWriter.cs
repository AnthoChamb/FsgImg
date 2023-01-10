using FsgImg.IO.Extensions;
using System.IO;
using System.Text;

namespace FsgImg.IO
{
    public class LittleEndianBinaryWriter : BinaryWriter
    {
        public LittleEndianBinaryWriter(Stream output) : base(output)
        {
        }

        public LittleEndianBinaryWriter(Stream output, Encoding encoding) : base(output, encoding)
        {
        }

        public LittleEndianBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen)
        {
        }

        public override void Write(short value)
        {
            this.WriteInt16LittleEndian(value);
        }

        public override void Write(int value)
        {
            this.WriteInt32LittleEndian(value);
        }

        public override void Write(long value)
        {
            this.WriteInt64LittleEndian(value);
        }

        public override void Write(ushort value)
        {
            this.WriteUInt16LittleEndian(value);
        }

        public override void Write(uint value)
        {
            this.WriteUInt32LittleEndian(value);
        }

        public override void Write(ulong value)
        {
            this.WriteUInt64LittleEndian(value);
        }
    }
}
