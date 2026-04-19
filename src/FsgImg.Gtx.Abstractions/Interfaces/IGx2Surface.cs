using FsgImg.Gtx.Abstractions.Enums;

namespace FsgImg.Gtx.Abstractions.Interfaces
{
    public interface IGx2Surface
    {
        Gx2SurfaceDimension Dimension { get; set; }
        uint Width { get; set; }
        uint Height { get; set; }
        uint Depth { get; set; }
        uint MipmapCount { get; set; }
        Gx2SurfaceTextureFormat TextureFormat { get; set; }
        uint MsaaSampleCount { get; set; }
        Gx2SurfaceUsageFlags Usage { get; set; }
        uint Size { get; set; }
        uint Offset { get; set; }
        uint MipmapSize { get; set; }
        uint MipmapOffset { get; set; }
        Gx2SurfaceTileMode TileMode { get; set; }
        uint Swizzle { get; set; }
        uint Alignment { get; set; }
        uint Pitch { get; set; }
        uint[] MipmapOffsets { get; set; }
        uint FirstMipmapId { get; set; }
        uint AvailableMipmapCount { get; set; }
        uint FirstSliceId { get; set; }
        uint AvailableSliceCount { get; set; }
        Gx2SurfaceColorChannel[] ColorChannels { get; set; }
        uint[] TextureRegisters { get; set; }
    }
}
