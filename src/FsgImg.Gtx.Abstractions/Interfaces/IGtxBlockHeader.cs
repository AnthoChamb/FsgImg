using FsgImg.Gtx.Abstractions.Enums;

namespace FsgImg.Gtx.Abstractions.Interfaces
{
    public interface IGtxBlockHeader
    {
        uint Magic { get; set; }
        uint Size { get; set; }
        uint MajorVersion { get; set; }
        uint MinorVersion { get; set; }
        GtxBlockType BlockType { get; set; }
        uint BlockSize { get; set; }
        uint BlockId { get; set; }
        uint BlockIndex { get; set; }
    }
}
