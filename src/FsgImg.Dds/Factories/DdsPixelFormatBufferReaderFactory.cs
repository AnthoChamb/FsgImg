﻿using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsPixelFormatBufferReaderFactory : IDdsPixelFormatBufferReaderFactory
    {
        public IDdsPixelFormatReader Create(byte[] buffer, int offset, int count)
        {
            return new DdsPixelFormatBufferReader(buffer, offset, count);
        }
    }
}
