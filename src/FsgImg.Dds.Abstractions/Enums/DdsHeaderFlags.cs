using System;

namespace FsgImg.Dds.Abstractions.Enums
{
    [Flags]
    public enum DdsHeaderFlags : uint
    {
        Caps = 0x1u,
        Height = 0x2u,
        Width = 0x4u,
        Pitch = 0x8u,
        PixelFormat = 0x1000u,
        MipmapCount = 0x20000u,
        LinearSize = 0x80000u,
        Depth = 0x800000u,

        Texture = Caps | Height | Width | PixelFormat
    }
}
