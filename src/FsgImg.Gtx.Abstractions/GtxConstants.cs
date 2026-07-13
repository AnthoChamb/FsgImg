namespace FsgImg.Gtx.Abstractions
{
    public class GtxConstants
    {
        public const string GtxExtension = ".gtx";
        public const uint Gfx2HeaderMagic = 0x47_66_78_32;
        public const int Gfx2HeaderSize = 32;
        public const uint GtxBlockHeaderMagic = 0x42_4C_4B_7B;
        public const int GtxBlockHeaderSize = 32;
        public const int Gx2SurfaceHeaderSize = 156;
        public const uint Gfx2V6GtxBlockMajorVersion = 0x00;
        public const uint Gfx2V6GtxBlockMinorVersion = 0x01;
        public const uint Gfx2V7GtxBlockMajorVersion = 0x01;
        public const uint Gfx2V7GtxBlockMinorVersion = 0x00;
    }
}
