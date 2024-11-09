using System;

namespace FsgImg.Dds.Abstractions.Enums
{
    [Flags]
    public enum DdsCaps2Flags : uint
    {
        Cubemap = 0x200u,
        CubemapPositiveX = 0x400u,
        CubemapNegativeX = 0x800u,
        CubemapPositiveY = 0x1000u,
        CubemapNegativeY = 0x2000u,
        CubemapPositiveZ = 0x4000u,
        CubemapNegativeZ = 0x8000u,
        Volume = 0x200000u
    }
}
