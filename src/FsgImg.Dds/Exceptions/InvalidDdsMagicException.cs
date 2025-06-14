using FsgImg.Abstractions.Exceptions;
using FsgImg.Dds.Abstractions;

namespace FsgImg.Dds.Exceptions
{
    public class InvalidDdsMagicException : FsgImgException
    {
        public uint Magic { get; }

        public InvalidDdsMagicException(uint magic)
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
            throw new InvalidDdsMagicException(magic);
        }

        public static void ThrowIfInvalid(uint magic)
        {
            if (magic != DdsConstants.DdsMagic)
            {
                Throw(magic);
            }
        }
    }
}
