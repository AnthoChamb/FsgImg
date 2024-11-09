using FsgImg.Abstractions.Exceptions;

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
    }
}
