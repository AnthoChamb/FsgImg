using FsgImg.Core.Interfaces.IO;
using System.IO;

namespace FsgImg.Core.Interfaces.Factories
{
    public interface IImgHeaderStreamReaderFactory
    {
        IImgHeaderReader Create(Stream stream, bool leaveOpen);
    }
}
