using FsgImg.IO.Extensions;
using System.IO;
using System.Text;

namespace FsgImg.IO
{
    public class BigEndianBinaryReader : BinaryReader
    {
        public BigEndianBinaryReader(Stream input) : base(input)
        {
        }

        public BigEndianBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public BigEndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public override short ReadInt16()
        {
            return this.ReadInt16BigEndian();
        }

        public override int ReadInt32()
        {
            return this.ReadInt32BigEndian();
        }

        public override long ReadInt64()
        {
            return this.ReadInt64BigEndian();
        }

        public override ushort ReadUInt16()
        {
            return this.ReadUInt16BigEndian();
        }

        public override uint ReadUInt32()
        {
            return this.ReadUInt32BigEndian();
        }

        public override ulong ReadUInt64()
        {
            return this.ReadUInt64BigEndian();
        }
    }
}
