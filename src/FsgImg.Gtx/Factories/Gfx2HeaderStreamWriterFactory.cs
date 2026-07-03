using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;
using System.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gfx2HeaderStreamWriterFactory : IGfx2HeaderStreamWriterFactory
    {
        private readonly IGfx2HeaderByteArrayWriterFactory _factory;

        public Gfx2HeaderStreamWriterFactory(IGfx2HeaderByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IGfx2HeaderWriter Create(Stream stream, bool leaveOpen)
        {
            return new Gfx2HeaderStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
