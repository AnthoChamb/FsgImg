using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using FsgImg.IO;

namespace FsgImg.Factories
{
    public class ImgHeaderByteArrayWriterFactory : IImgHeaderByteArrayWriterFactory
    {
        public IImgHeaderWriter Create(byte[] buffer, int offset, int count)
        {
            return new ImgHeaderByteArrayWriter(buffer, offset, count);
        }
    }
}
