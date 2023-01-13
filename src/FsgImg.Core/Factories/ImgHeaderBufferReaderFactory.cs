using FsgImg.Core.Interfaces.Factories;
using FsgImg.Core.Interfaces.IO;
using FsgImg.Core.IO;

namespace FsgImg.Core.Factories
{
    public class ImgHeaderBufferReaderFactory : IImgHeaderBufferReaderFactory
    {
        public IImgHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new ImgHeaderBufferReader(buffer, offset, count);
        }
    }
}
