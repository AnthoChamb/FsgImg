using FsgImg.Dds.Abstractions.Enums;

namespace FsgImg.Dds.Abstractions.Interfaces
{
    public interface IDdsHeader
    {
        uint Size { get; set; }
        DdsHeaderFlags Flags { get; set; }
        uint Height { get; set; }
        uint Width { get; set; }
        uint PitchOrLinearSize { get; set; }
        uint Depth { get; set; }
        uint MipmapCount { get; set; }
        uint[] Reserved { get; set; }
        IDdsPixelFormat PixelFormat { get; set; }
        DdsCapsFlags Caps { get; set; }
        DdsCaps2Flags Caps2 { get; set; }
        uint Caps3 { get; set; }
        uint Caps4 { get; set; }
        uint Reserved2 { get; set; }
    }
}
