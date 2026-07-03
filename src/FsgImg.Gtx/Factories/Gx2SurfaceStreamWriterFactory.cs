using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;
using System.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gx2SurfaceStreamWriterFactory : IGx2SurfaceStreamWriterFactory
    {
        private readonly IGx2SurfaceByteArrayWriterFactory _factory;

        public Gx2SurfaceStreamWriterFactory(IGx2SurfaceByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IGx2SurfaceWriter Create(Stream stream, bool leaveOpen)
        {
            return new Gx2SurfaceStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
