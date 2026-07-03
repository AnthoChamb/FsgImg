using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGtxBlockHeaderStreamReaderFactory
    {
        IGtxBlockHeaderReader Create(Stream stream, bool leaveOpen);
    }
}
