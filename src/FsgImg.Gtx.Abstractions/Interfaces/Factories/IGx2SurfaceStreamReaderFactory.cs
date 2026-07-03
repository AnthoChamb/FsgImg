using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGx2SurfaceStreamReaderFactory
    {
        IGx2SurfaceReader Create(Stream stream, bool leaveOpen);
    }
}
