namespace FsgImg.Abstractions.Enums
{
    public enum ImgTextureFormat : uint
    {
        DdsDxt1 = 0x00_05_00_00u,
        DdsDxt3 = 0x00_07_00_01u,
        DdsDxt5 = 0x00_09_00_FFu,
        DdsRgba8 = 0x00_03_00_00u,
        Tex0Cmpr = 0x00_05_00_00u,
        Tex0Rgb5A3 = 0x00_02_00_00u,
        Tex0Ia4 = 0x00_01_00_00u,
        Gtx = 0x00_05_00_00u,
        Pvr = 0x00_00_00_00u
    }
}
