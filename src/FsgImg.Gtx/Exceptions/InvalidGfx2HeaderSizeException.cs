using FsgImg.Abstractions.Exceptions;
using FsgImg.Gtx.Abstractions;

namespace FsgImg.Gtx.Exceptions
{
    public class InvalidGfx2HeaderSizeException : FsgImgException
    {
        public uint Size { get; }

        public InvalidGfx2HeaderSizeException(uint size)
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
            throw new InvalidGfx2HeaderSizeException(size);
        }

        public static void ThrowIfInvalid(uint size)
        {
            if (size != GtxConstants.Gfx2HeaderSize)
            {
                Throw(size);
            }
        }
    }
}
