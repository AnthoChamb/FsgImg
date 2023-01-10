﻿using FsgImg.Dds.Enums;

namespace FsgImg.Dds.Interfaces
{
    public interface IDdsPixelFormat
    {
        uint Size { get; set; }
        DdsPixelFormatFlags Flags { get; set; }
        DdsFourCc FourCc { get; set; }
        uint RgbBitCount { get; set; }
        uint RBitMask { get; set; }
        uint GBitMask { get; set; }
        uint BBitMask { get; set; }
        uint ABitMask { get; set; }
    }
}