using FsgImg.Abstractions.Exceptions;
using FsgImg.Dds.Abstractions;

namespace FsgImg.Dds.Exceptions
{
    public class InvalidDdsHeaderSizeException : FsgImgException
    {
        public uint Size { get; }

        public InvalidDdsHeaderSizeException(uint size)
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
            throw new InvalidDdsHeaderSizeException(size);
        }

        public static void ThrowIfInvalid(uint size)
        {
            if (size != DdsConstants.DdsHeaderSize)
            {
                Throw(size);
            }
        }
    }
}
