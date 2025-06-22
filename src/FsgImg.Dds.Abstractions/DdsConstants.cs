namespace FsgImg.Dds.Abstractions
{
    public class DdsConstants
    {
        public const uint DdsMagic = 0x20_53_44_44u;
        public const int DdsHeaderSize = 124;
        public const int DdsPixelFormatSize = 32;
        public const int DdsHeaderDxt10Size = 20;
        public const uint DdsBlockWidth = 4;
        public const uint DdsBlockHeight = 4;
        public const uint DdsBc1BlockSize = 8;
        public const uint DdsBc2BlockSize = 16;
        public const uint DdsBc3BlockSize = 16;
        public const uint DdsBc4BlockSize = 8;
        public const uint DdsBc5BlockSize = 16;
        public const uint DdsBc6HBlockSize = 16;
        public const uint DdsBc7BlockSize = 16;
    }
}
