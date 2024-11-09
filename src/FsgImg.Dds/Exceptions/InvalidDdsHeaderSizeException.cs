using FsgImg.Abstractions.Exceptions;

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
    }
}
