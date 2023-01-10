using FsgImg.Core.Interfaces;
using FsgImg.Core.IO;
using System.IO;

namespace FsgImg.Core.Factories
{
    public class ImgHeaderStreamWriterFactory : IImgHeaderStreamWriterFactory
    {
        private readonly IImgHeaderBufferWriterFactory _factory;

        public ImgHeaderStreamWriterFactory(IImgHeaderBufferWriterFactory factory)
        {
            _factory = factory;
        }

        public IImgHeaderWriter Create(Stream stream, bool leaveOpen)
        {
            return new ImgHeaderStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
