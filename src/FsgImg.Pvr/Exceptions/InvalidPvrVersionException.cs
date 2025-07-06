using FsgImg.Abstractions.Exceptions;
using FsgImg.Pvr.Abstractions;

namespace FsgImg.Pvr.Exceptions
{
    public class InvalidPvrVersionException : FsgImgException
    {
        public uint Version { get; }

        public InvalidPvrVersionException(uint version)
        {
            Version = version;
        }

        public override string Message
        {
            get
            {
                // TODO: Return resource string
                return string.Empty;
            }
        }

        public static void Throw(uint version)
        {
            throw new InvalidPvrVersionException(version);
        }

        public static void ThrowIfInvalid(uint version)
        {
            if (version != PvrConstants.PvrVersion)
            {
                Throw(version);
            }
        }
    }
}
