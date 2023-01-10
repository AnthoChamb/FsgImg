using FsgImg.IO.Extensions;
using System.IO;
using System.Text;

namespace FsgImg.IO
{
    public class BigEndianBinaryWriter : BinaryWriter
    {
        public BigEndianBinaryWriter(Stream output) : base(output)
        {
        }

        public BigEndianBinaryWriter(Stream output, Encoding encoding) : base(output, encoding)
        {
        }

        public BigEndianBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen)
        {
        }

        public override void Write(short value)
        {
            this.WriteInt16BigEndian(value);
        }

        public override void Write(int value)
        {
            this.WriteInt32BigEndian(value);
        }

        public override void Write(long value)
        {
            this.WriteInt64BigEndian(value);
        }

        public override void Write(ushort value)
        {
            this.WriteUInt16BigEndian(value);
        }

        public override void Write(uint value)
        {
            this.WriteUInt32BigEndian(value);
        }

        public override void Write(ulong value)
        {
            this.WriteUInt64BigEndian(value);
        }
    }
}
