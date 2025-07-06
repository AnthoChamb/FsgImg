using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions.Interfaces.IO;
using FsgImg.Pvr.IO;

namespace FsgImg.Pvr.Factories
{
    public class PvrHeaderByteArrayReaderFactory : IPvrHeaderByteArrayReaderFactory
    {
        public IPvrHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new PvrHeaderByteArrayReader(buffer, offset, count);
        }
    }
}
