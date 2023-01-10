using System;

namespace FsgImg.Dds.Enums
{
    [Flags]
    public enum DdsCapsFlags : uint
    {
        Complex = 0x8u,
        Mipmap = 0x400000u,
        Texture = 0x1000u
    }
}
