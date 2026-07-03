using FsgImg.Gtx.Abstractions.Enums;
using FsgImg.Gtx.Abstractions.Interfaces;

namespace FsgImg.Gtx
{
    public class Gx2Surface : IGx2Surface
    {
        public Gx2SurfaceDimension Dimension { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint Depth { get; set; }
        public uint MipmapCount { get; set; }
        public Gx2SurfaceTextureFormat TextureFormat { get; set; }
        public uint MsaaSampleCount { get; set; }
        public Gx2SurfaceUsageFlags Usage { get; set; }
        public uint Size { get; set; }
        public uint Offset { get; set; }
        public uint MipmapSize { get; set; }
        public uint MipmapOffset { get; set; }
        public Gx2SurfaceTileMode TileMode { get; set; }
        public uint Swizzle { get; set; }
        public uint Alignment { get; set; }
        public uint Pitch { get; set; }
        public uint[] MipmapOffsets { get; set; } = new uint[13];
        public uint FirstMipmapId { get; set; }
        public uint AvailableMipmapCount { get; set; }
        public uint FirstSliceId { get; set; }
        public uint AvailableSliceCount { get; set; }
        public Gx2SurfaceColorChannel[] ColorChannels { get; set; } = new Gx2SurfaceColorChannel[4];
        public uint[] TextureRegisters { get; set; } = new uint[5];
    }
}
