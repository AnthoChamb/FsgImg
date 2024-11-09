using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsHeaderDxt10StreamReaderFactory
    {
        IDdsHeaderDxt10Reader Create(Stream stream, bool leaveOpen);
    }
}
