using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using FsgImg.IO;

namespace FsgImg.Factories
{
    public class ImgHeaderByteArrayReaderFactory : IImgHeaderByteArrayReaderFactory
    {
        private readonly IImgHeaderFactory _factory;

        public ImgHeaderByteArrayReaderFactory(IImgHeaderFactory factory)
        {
            _factory = factory;
        }

        public IImgHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new ImgHeaderByteArrayReader(_factory, buffer, offset, count);
        }
    }
}
