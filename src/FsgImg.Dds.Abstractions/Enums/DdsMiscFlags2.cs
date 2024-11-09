using System;

namespace FsgImg.Dds.Abstractions.Enums
{
    [Flags]
    public enum DdsMiscFlags2 : uint
    {
        AlphaModeUnknown = 0x0,
        AlphaModeStraight = 0x1,
        AlphaModePremultiplied = 0x2,
        AlphaModeOpaque = 0x3,
        AlphaModeCustom = 0x4
    }
}
