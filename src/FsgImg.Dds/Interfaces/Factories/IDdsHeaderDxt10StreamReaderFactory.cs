using FsgImg.Dds.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderDxt10StreamReaderFactory
    {
        IDdsHeaderDxt10Reader Create(Stream stream, bool leaveOpen);
    }
}
