using FsgImg.Dds.Abstractions.Interfaces.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsHeaderBufferReaderFactory
    {
        IDdsHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
