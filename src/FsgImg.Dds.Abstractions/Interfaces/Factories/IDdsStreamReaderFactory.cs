using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsStreamReaderFactory
    {
        IDdsReader Create(Stream stream, bool leaveOpen);
    }
}
