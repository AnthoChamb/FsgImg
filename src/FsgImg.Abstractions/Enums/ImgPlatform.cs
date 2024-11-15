﻿namespace FsgImg.Abstractions.Enums
{
    public enum ImgPlatform : ushort
    {
        /// <summary>
        /// <see cref="ImgGame.Djh"/> does not specify an <see cref="ImgPlatform"/>.
        /// </summary>
        Unknown = 0x00_00,
        Xbox360 = 0x03_00,
        PlayStation3 = 0x03_01,
        Pc = 0x03_03,
        WiiU = 0x03_04,
        XboxOne = 0x03_05,
        IOs = 0x00_06
    }
}
