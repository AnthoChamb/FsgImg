using FsgImg.Core.Interfaces.Factories;
using FsgImg.Core.Interfaces.IO;
using FsgImg.Core.IO;
using System.IO;

namespace FsgImg.Core.Factories
{
    public class ImgHeaderStreamReaderFactory : IImgHeaderStreamReaderFactory
    {
        private readonly IImgHeaderBufferReaderFactory _factory;

        public ImgHeaderStreamReaderFactory(IImgHeaderBufferReaderFactory factory)
        {
            _factory = factory;
        }

        public IImgHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new ImgHeaderStreamReader(stream, _factory, leaveOpen);
        }
    }
}
