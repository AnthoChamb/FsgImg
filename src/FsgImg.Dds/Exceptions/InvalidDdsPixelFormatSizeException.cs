using FsgImg.Abstractions.Exceptions;
using FsgImg.Dds.Abstractions;

namespace FsgImg.Dds.Exceptions
{
    public class InvalidDdsPixelFormatSizeException : FsgImgException
    {
        public uint Size { get; }

        public InvalidDdsPixelFormatSizeException(uint size)
        {
            Size = size;
        }

        public override string Message
        {
            get
            {
                // TODO: Return resource string
                return string.Empty;
            }
        }

        public static void Throw(uint size)
        {
            throw new InvalidDdsPixelFormatSizeException(size);
        }

        public static void ThrowIfInvalid(uint size)
        {
            if (size != DdsConstants.DdsPixelFormatSize)
            {
                Throw(size);
            }
        }
    }
}
