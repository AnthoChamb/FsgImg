using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGfx2HeaderStreamReaderFactory
    {
        IGfx2HeaderReader Create(Stream stream, bool leaveOpen);
    }
}
