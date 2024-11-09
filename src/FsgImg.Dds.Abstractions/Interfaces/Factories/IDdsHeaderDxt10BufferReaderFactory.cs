using FsgImg.Dds.Abstractions.Interfaces.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsHeaderDxt10BufferReaderFactory
    {
        IDdsHeaderDxt10Reader Create(byte[] buffer, int offset, int count);
    }
}
