using FsgImg.Gtx.Abstractions.Enums;
using FsgImg.Gtx.Abstractions.Interfaces;

namespace FsgImg.Gtx
{
    public class GtxBlockHeader : IGtxBlockHeader
    {
        public uint Magic { get; set; }
        public uint Size { get; set; }
        public uint MajorVersion { get; set; }
        public uint MinorVersion { get; set; }
        public GtxBlockType BlockType { get; set; }
        public uint BlockSize { get; set; }
        public uint BlockId { get; set; }
        public uint BlockIndex { get; set; }
    }
}
