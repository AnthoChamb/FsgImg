using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGfx2HeaderStreamWriterFactory
    {
        IGfx2HeaderWriter Create(Stream stream, bool leaveOpen);
    }
}
