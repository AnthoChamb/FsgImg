using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions.Interfaces.IO;
using FsgImg.Pvr.IO;

namespace FsgImg.Pvr.Factories
{
    public class PvrHeaderByteArrayWriterFactory : IPvrHeaderByteArrayWriterFactory
    {
        public IPvrHeaderWriter Create(byte[] buffer, int offset, int count)
        {
            return new PvrHeaderByteArrayWriter(buffer, offset, count);
        }
    }
}
