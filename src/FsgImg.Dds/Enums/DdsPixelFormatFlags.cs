using System;

namespace FsgImg.Dds.Enums
{
    [Flags]
    public enum DdsPixelFormatFlags : uint
    {
        AlphaPixels = 0x1u,
        Alpha = 0x2u,
        FourCc = 0x4u,
        Rgb = 0x40u,
        Yuv = 0x200u,
        Luminance = 0x20000u
    }
}
