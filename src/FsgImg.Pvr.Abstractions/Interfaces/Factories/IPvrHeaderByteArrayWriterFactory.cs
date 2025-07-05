using FsgImg.Pvr.Abstractions.Interfaces.IO;

namespace FsgImg.Pvr.Abstractions.Interfaces.Factories
{
    public interface IPvrHeaderByteArrayWriterFactory
    {
        IPvrHeaderWriter Create(byte[] buffer, int offset, int count);
    }
}
