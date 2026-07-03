using FsgImg.Gtx.Abstractions.Interfaces.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGfx2HeaderByteArrayReaderFactory
    {
        IGfx2HeaderReader Create(byte[] buffer, int offset, int count);
    }
}
