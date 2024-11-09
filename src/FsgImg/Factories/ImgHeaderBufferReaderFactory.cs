using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using FsgImg.IO;

namespace FsgImg.Factories
{
    public class ImgHeaderBufferReaderFactory : IImgHeaderBufferReaderFactory
    {
        public IImgHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new ImgHeaderBufferReader(buffer, offset, count);
        }
    }
}
