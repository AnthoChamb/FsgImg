using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;
using System.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gfx2HeaderStreamReaderFactory : IGfx2HeaderStreamReaderFactory
    {
        private readonly IGfx2HeaderByteArrayReaderFactory _factory;

        public Gfx2HeaderStreamReaderFactory(IGfx2HeaderByteArrayReaderFactory factory)
        {
            _factory = factory;
        }

        public IGfx2HeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new Gfx2HeaderStreamReader(stream, _factory, leaveOpen);
        }
    }
}
