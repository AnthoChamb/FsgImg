using FsgImg.Abstractions.Exceptions;
using FsgImg.Gtx.Abstractions;

namespace FsgImg.Gtx.Exceptions
{
    public class InvalidGfx2HeaderMagicException : FsgImgException
    {
        public uint Magic { get; }

        public InvalidGfx2HeaderMagicException(uint magic)
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
            throw new InvalidGfx2HeaderMagicException(magic);
        }

        public static void ThrowIfInvalid(uint magic)
        {
            if (magic != GtxConstants.Gfx2HeaderMagic)
            {
                Throw(magic);
            }
        }
    }
}
