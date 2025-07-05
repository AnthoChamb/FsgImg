using FsgImg.Pvr.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Pvr.Abstractions.Interfaces.Factories
{
    public interface IPvrHeaderStreamWriterFactory
    {
        IPvrHeaderWriter Create(Stream stream, bool leaveOpen);
    }
}
