using FsgImg.Dds.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsFileStreamReaderFactory
    {
        IDdsFileReader Create(Stream stream, bool leaveOpen);
    }
}
