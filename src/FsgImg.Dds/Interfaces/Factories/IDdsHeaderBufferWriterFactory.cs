using FsgImg.Dds.Interfaces.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderBufferWriterFactory
    {
        IDdsHeaderWriter Create(byte[] buffer, int offset, int count);
    }
}
