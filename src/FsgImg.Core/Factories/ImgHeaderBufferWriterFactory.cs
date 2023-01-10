using FsgImg.Core.Interfaces;
using FsgImg.Core.IO;

namespace FsgImg.Core.Factories
{
    public class ImgHeaderBufferWriterFactory : IImgHeaderBufferWriterFactory
    {
        public IImgHeaderWriter Create(byte[] buffer, int offset, int count)
        {
            return new ImgHeaderBufferWriter(buffer, offset, count);
        }
    }
}
