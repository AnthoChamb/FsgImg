using FsgImg.Dds.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderStreamWriterFactory
    {
        IDdsHeaderWriter Create(Stream stream, bool leaveOpen);
    }
}
