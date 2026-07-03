using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGx2SurfaceStreamWriterFactory
    {
        IGx2SurfaceWriter Create(Stream stream, bool leaveOpen);
    }
}
