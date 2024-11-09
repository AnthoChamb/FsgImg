using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Interfaces;

namespace FsgImg.Dds
{
    public class DdsPixelFormat : IDdsPixelFormat
    {
        public uint Size { get; set; } = DdsConstants.DdsPixelFormatSize;
        public DdsPixelFormatFlags Flags { get; set; }
        public DdsFourCc FourCc { get; set; }
        public uint RgbBitCount { get; set; }
        public uint RBitMask { get; set; }
        public uint GBitMask { get; set; }
        public uint BBitMask { get; set; }
        public uint ABitMask { get; set; }
    }
}
