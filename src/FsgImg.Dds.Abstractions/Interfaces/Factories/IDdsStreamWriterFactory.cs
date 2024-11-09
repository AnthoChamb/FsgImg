using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsStreamWriterFactory
    {
        IDdsWriter Create(Stream stream, bool leaveOpen);
    }
}
