using FsgImg.Dds.Enums;
using FsgImg.Dds.Interfaces;

namespace FsgImg.Dds
{
    public class DdsPixelFormat : IDdsPixelFormat
    {
        public uint Size { get; set; } = 32;
        public DdsPixelFormatFlags Flags { get; set; }
        public DdsFourCc FourCc { get; set; }
        public uint RgbBitCount { get; set; }
        public uint RBitMask { get; set; }
        public uint GBitMask { get; set; }
        public uint BBitMask { get; set; }
        public uint ABitMask { get; set; }
    }
}
