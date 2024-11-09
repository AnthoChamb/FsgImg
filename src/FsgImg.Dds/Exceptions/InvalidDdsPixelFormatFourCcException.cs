﻿using FsgImg.Abstractions.Exceptions;
using FsgImg.Dds.Abstractions.Enums;

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
