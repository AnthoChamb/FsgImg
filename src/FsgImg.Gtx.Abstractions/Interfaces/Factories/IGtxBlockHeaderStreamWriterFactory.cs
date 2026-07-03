using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGtxBlockHeaderStreamWriterFactory
    {
        IGtxBlockHeaderWriter Create(Stream stream, bool leaveOpen);
    }
}
