using FsgImg.Core.Interfaces.IO;

namespace FsgImg.Core.Interfaces.Factories
{
    public interface IImgHeaderBufferWriterFactory
    {
        IImgHeaderWriter Create(byte[] buffer, int offset, int count);
    }
}
