using FsgImg.Dds.Enums;
using FsgImg.Dds.Interfaces;

namespace FsgImg.Dds
{
    public class DdsHeader : IDdsHeader
    {
        public uint Size { get; set; } = 124;
        public DdsHeaderFlags Flags { get; set; } = DdsHeaderFlags.Texture;
        public uint Height { get; set; }
        public uint Width { get; set; }
        public uint PitchOrLinearSize { get; set; }
        public uint Depth { get; set; }
        public uint MipmapCount { get; set; }
        public uint[] Reserved { get; set; } = new uint[11];
        public IDdsPixelFormat PixelFormat { get; set; }
        public DdsCapsFlags Caps { get; set; } = DdsCapsFlags.Texture;
        public DdsCaps2Flags Caps2 { get; set; }
        public uint Caps3 { get; set; }
        public uint Caps4 { get; set; }
        public uint Reserved2 { get; set; }
    }
}
