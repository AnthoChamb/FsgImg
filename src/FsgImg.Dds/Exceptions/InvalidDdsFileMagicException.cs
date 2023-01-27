using FsgImg.Core.Exceptions;

namespace FsgImg.Dds.Exceptions
{
    public class InvalidDdsFileMagicException : FsgImgException
    {
        public uint Magic { get; }

        public InvalidDdsFileMagicException(uint magic)
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
