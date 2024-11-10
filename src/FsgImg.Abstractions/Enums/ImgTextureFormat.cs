namespace FsgImg.Abstractions.Enums
{
    public enum ImgTextureFormat : uint
    {
        Unknown = 0x00_00_00_00u,
        Ia4 = 0x00_00_00_01u,
        Rgb5A3 = 0x00_00_00_02u,
        Rgba8 = 0x00_00_00_03u,
        Bc1 = 0x00_00_00_05u,
        Bc2 = 0x00_00_00_07u,
        Bc3 = 0x00_00_00_09u
    }
}
