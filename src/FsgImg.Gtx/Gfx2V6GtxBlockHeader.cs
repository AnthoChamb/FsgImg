using FsgImg.Gtx.Abstractions;
using FsgImg.Gtx.Abstractions.Enums;
using FsgImg.Gtx.Abstractions.Interfaces;

namespace FsgImg.Gtx
{
    public class Gfx2V6GtxBlockHeader : IGtxBlockHeader
    {
        public uint Magic { get; set; } = GtxConstants.GtxBlockHeaderMagic;
        public uint Size { get; set; } = GtxConstants.GtxBlockHeaderSize;
        public uint MajorVersion { get; set; } = GtxConstants.Gfx2V6GtxBlockMajorVersion;
        public uint MinorVersion { get; set; } = GtxConstants.Gfx2V6GtxBlockMinorVersion;
        public Gfx2V6GtxBlockType BlockType { get; set; }
        public uint BlockSize { get; set; }
        public uint BlockId { get; set; }
        public uint BlockIndex { get; set; }

        GtxBlockType IGtxBlockHeader.BlockType
        {
            get
            {
                return (GtxBlockType)BlockType;
            }

            set
            {
                BlockType = (Gfx2V6GtxBlockType)value;
            }
        }
    }
}
