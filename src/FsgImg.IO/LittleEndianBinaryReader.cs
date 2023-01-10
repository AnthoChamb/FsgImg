using FsgImg.IO.Extensions;
using System.IO;
using System.Text;

namespace FsgImg.IO
{
    public class LittleEndianBinaryReader : BinaryReader
    {
        public LittleEndianBinaryReader(Stream input) : base(input)
        {
        }

        public LittleEndianBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public LittleEndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public override short ReadInt16()
        {
            return this.ReadInt16LittleEndian();
        }

        public override int ReadInt32()
        {
            return this.ReadInt32LittleEndian();
        }

        public override long ReadInt64()
        {
            return this.ReadInt64LittleEndian();
        }

        public override ushort ReadUInt16()
        {
            return this.ReadUInt16LittleEndian();
        }

        public override uint ReadUInt32()
        {
            return this.ReadUInt32LittleEndian();
        }

        public override ulong ReadUInt64()
        {
            return this.ReadUInt64LittleEndian();
        }
    }
}
