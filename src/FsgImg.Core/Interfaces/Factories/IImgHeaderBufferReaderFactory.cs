using FsgImg.Core.Interfaces.IO;

namespace FsgImg.Core.Interfaces.Factories
{
    public interface IImgHeaderBufferReaderFactory
    {
        IImgHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
