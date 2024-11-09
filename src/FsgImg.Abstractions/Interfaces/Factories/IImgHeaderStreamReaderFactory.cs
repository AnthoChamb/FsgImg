using FsgImg.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Abstractions.Interfaces.Factories
{
    public interface IImgHeaderStreamReaderFactory
    {
        IImgHeaderReader Create(Stream stream, bool leaveOpen);
    }
}
