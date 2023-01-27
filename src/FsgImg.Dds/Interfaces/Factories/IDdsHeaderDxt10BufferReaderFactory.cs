using FsgImg.Dds.Interfaces.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderDxt10BufferReaderFactory
    {
        IDdsHeaderDxt10Reader Create(byte[] buffer, int offset, int count);
    }
}
