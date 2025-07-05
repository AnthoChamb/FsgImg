using FsgImg.Pvr.Abstractions.Interfaces.IO;

namespace FsgImg.Pvr.Abstractions.Interfaces.Factories
{
    public interface IPvrHeaderByteArrayReaderFactory
    {
        IPvrHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
