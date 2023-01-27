using FsgImg.Dds.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderStreamReaderFactory
    {
        IDdsHeaderReader Create(Stream stream, bool leaveOpen);
    }
}
