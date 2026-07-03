using FsgImg.Gtx.Abstractions;
using FsgImg.Gtx.Abstractions.Interfaces;

namespace FsgImg.Gtx
{
    public class Gfx2Header : IGfx2Header
    {
        public uint Magic { get; set; } = GtxConstants.Gfx2HeaderMagic;
        public uint Size { get; set; } = GtxConstants.Gfx2HeaderSize;
        public uint MajorVersion { get; set; }
        public uint MinorVersion { get; set; }
        public uint GpuVersion { get; set; }
        public uint AlignMode { get; set; }
        public uint Reserved { get; set; }
        public uint Reserved2 { get; set; }
    }
}
