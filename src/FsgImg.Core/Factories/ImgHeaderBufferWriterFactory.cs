using FsgImg.Core.Interfaces.Factories;
using FsgImg.Core.Interfaces.IO;
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
