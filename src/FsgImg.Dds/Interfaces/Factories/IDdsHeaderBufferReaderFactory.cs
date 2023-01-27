using FsgImg.Dds.Interfaces.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderBufferReaderFactory
    {
        IDdsHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
