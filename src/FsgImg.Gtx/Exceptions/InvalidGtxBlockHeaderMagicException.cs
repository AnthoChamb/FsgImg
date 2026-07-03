using FsgImg.Abstractions.Exceptions;
using FsgImg.Gtx.Abstractions;

namespace FsgImg.Gtx.Exceptions
{
    public class InvalidGtxBlockHeaderMagicException : FsgImgException
    {
        public uint Magic { get; }

        public InvalidGtxBlockHeaderMagicException(uint magic)
        {
            Magic = magic;
        }

        public override string Message
        {
            get
            {
                // TODO: Return resource string
                return string.Empty;
            }
        }

        public static void Throw(uint magic)
        {
            throw new InvalidGtxBlockHeaderMagicException(magic);
        }

        public static void ThrowIfInvalid(uint magic)
        {
            if (magic != GtxConstants.GtxBlockHeaderMagic)
            {
                Throw(magic);
            }
        }
    }
}
