using FsgImg.Abstractions.Interfaces.IO;

namespace FsgImg.Abstractions.Interfaces.Factories
{
    public interface IImgHeaderByteArrayWriterFactory
    {
        IImgHeaderWriter Create(byte[] buffer, int offset, int count);
    }
}
