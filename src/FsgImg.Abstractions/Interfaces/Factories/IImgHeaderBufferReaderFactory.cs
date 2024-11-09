using FsgImg.Abstractions.Interfaces.IO;

namespace FsgImg.Abstractions.Interfaces.Factories
{
    public interface IImgHeaderBufferReaderFactory
    {
        IImgHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
