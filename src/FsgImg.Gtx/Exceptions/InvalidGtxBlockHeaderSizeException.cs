using FsgImg.Abstractions.Exceptions;
using FsgImg.Gtx.Abstractions;

namespace FsgImg.Gtx.Exceptions
{
    public class InvalidGtxBlockHeaderSizeException : FsgImgException
    {
        public uint Size { get; }

        public InvalidGtxBlockHeaderSizeException(uint size)
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
            throw new InvalidGtxBlockHeaderSizeException(size);
        }

        public static void ThrowIfInvalid(uint size)
        {
            if (size != GtxConstants.GtxBlockHeaderSize)
            {
                Throw(size);
            }
        }
    }
}
