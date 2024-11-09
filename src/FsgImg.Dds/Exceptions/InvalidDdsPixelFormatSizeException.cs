using FsgImg.Abstractions.Exceptions;

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
    }
}
