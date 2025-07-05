using FsgImg.Dds.Abstractions.Interfaces.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsHeaderByteArrayWriterFactory
    {
        IDdsHeaderWriter Create(byte[] buffer, int offset, int count);
    }
}
