using System;

namespace FsgImg.Abstractions.Exceptions
{
    public class FsgImgException : Exception
    {
        public FsgImgException()
        {
        }

        public FsgImgException(string message) : base(message)
        {
        }

        public FsgImgException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
