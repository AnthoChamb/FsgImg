using FsgImg.Core.Exceptions;
using FsgImg.Dds.Enums;

namespace FsgImg.Dds.Exceptions
{
    public class InvalidDxgiFormatException : FsgImgException
    {
        public DxgiFormat DxgiFormat { get; }

        public InvalidDxgiFormatException(DxgiFormat dxgiFormat)
        {
            DxgiFormat = dxgiFormat;
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
