using FsgImg.Core.Exceptions;
using FsgImg.Dds.Enums;

namespace FsgImg.Dds.Exceptions
{
    public class InvalidDdsPixelFormatFourCcException : FsgImgException
    {
        public DdsFourCc FourCc { get; }

        public InvalidDdsPixelFormatFourCcException(DdsFourCc fourCc)
        {
            FourCc = fourCc;
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
