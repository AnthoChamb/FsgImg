using FsgImg.Pvr.Abstractions.Enums;

namespace FsgImg.Pvr.Abstractions.Interfaces
{
    public interface IPvrHeader
    {
        uint Version { get; set; }
        PvrHeaderFlags Flags { get; set; }
        PvrPixelFormat PixelFormat { get; set; }
        PvrColourSpace ColourSpace { get; set; }
        PvrChannelType ChannelType { get; set; }
        uint Height { get; set; }
        uint Width { get; set; }
        uint Depth { get; set; }
        uint NumSurfaces { get; set; }
        uint NumFaces { get; set; }
        uint MipmapCount { get; set; }
        uint MetadataSize { get; set; }
    }
}
