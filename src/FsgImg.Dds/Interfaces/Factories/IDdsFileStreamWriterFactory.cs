using FsgImg.Dds.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsFileStreamWriterFactory
    {
        IDdsFileWriter Create(Stream stream, bool leaveOpen);
    }
}
