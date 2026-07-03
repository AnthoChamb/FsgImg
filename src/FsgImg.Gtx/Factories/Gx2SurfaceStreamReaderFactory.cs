using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;
using System.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gx2SurfaceStreamReaderFactory : IGx2SurfaceStreamReaderFactory
    {
        private readonly IGx2SurfaceByteArrayReaderFactory _factory;

        public Gx2SurfaceStreamReaderFactory(IGx2SurfaceByteArrayReaderFactory factory)
        {
            _factory = factory;
        }

        public IGx2SurfaceReader Create(Stream stream, bool leaveOpen)
        {
            return new Gx2SurfaceStreamReader(stream, _factory, leaveOpen);
        }
    }
}
