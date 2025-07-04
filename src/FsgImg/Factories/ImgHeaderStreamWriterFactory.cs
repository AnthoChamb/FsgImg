﻿using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using FsgImg.IO;
using System.IO;

namespace FsgImg.Factories
{
    public class ImgHeaderStreamWriterFactory : IImgHeaderStreamWriterFactory
    {
        private readonly IImgHeaderByteArrayWriterFactory _factory;

        public ImgHeaderStreamWriterFactory(IImgHeaderByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IImgHeaderWriter Create(Stream stream, bool leaveOpen)
        {
            return new ImgHeaderStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
