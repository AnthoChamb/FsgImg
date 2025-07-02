using FsgImg.Pvr.Abstractions;
using FsgImg.Pvr.Abstractions.Enums;
using FsgImg.Pvr.Abstractions.Interfaces;

namespace FsgImg.Pvr
{
    public class PvrHeader : IPvrHeader
    {
        public uint Version { get; set; } = PvrConstants.PvrVersion;
        public PvrFlags Flags { get; set; }
        public PvrPixelFormat PixelFormat { get; set; }
        public PvrColourSpace ColourSpace { get; set; }
        public PvrChannelType ChannelType { get; set; }
        public uint Height { get; set; }
        public uint Width { get; set; }
        public uint Depth { get; set; }
        public uint NumSurfaces { get; set; }
        public uint NumFaces { get; set; }
        public uint MipmapCount { get; set; }
        public uint MetadataSize { get; set; }
    }
}
