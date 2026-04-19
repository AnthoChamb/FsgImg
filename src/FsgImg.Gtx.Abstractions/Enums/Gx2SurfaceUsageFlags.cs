using System;

namespace FsgImg.Gtx.Abstractions.Enums
{
    [Flags]
    public enum Gx2SurfaceUsageFlags : uint
    {
        Texture = 0x01,
        ColorBuffer = 0x02,
        DepthBuffer = 0x04,
        ScanBuffer = 0x08,
        Ftv = 0x80_00_00_00
    }
}
