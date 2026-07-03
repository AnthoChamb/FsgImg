using FsgImg.Gtx.Abstractions.Interfaces.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGfx2HeaderByteArrayWriterFactory
    {
        IGfx2HeaderWriter Create(byte[] buffer, int offset, int count);
    }
}
