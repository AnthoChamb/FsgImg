﻿using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using FsgImg.IO;
using System.IO;

namespace FsgImg.Factories
{
    public class ImgHeaderStreamReaderFactory : IImgHeaderStreamReaderFactory
    {
        private readonly IImgHeaderByteArrayReaderFactory _factory;

        public ImgHeaderStreamReaderFactory(IImgHeaderByteArrayReaderFactory factory)
        {
            _factory = factory;
        }

        public IImgHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new ImgHeaderStreamReader(stream, _factory, leaveOpen);
        }
    }
}
