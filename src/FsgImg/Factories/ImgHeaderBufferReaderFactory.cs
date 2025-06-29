using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using FsgImg.IO;

namespace FsgImg.Factories
{
    public class ImgHeaderBufferReaderFactory : IImgHeaderBufferReaderFactory
    {
        private readonly IImgHeaderFactory _factory;

        public ImgHeaderBufferReaderFactory(IImgHeaderFactory factory)
        {
            _factory = factory;
        }

        public IImgHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new ImgHeaderBufferReader(_factory, buffer, offset, count);
        }
    }
}
