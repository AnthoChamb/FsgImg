using System.IO;

namespace FsgImg.Core.Interfaces
{
    public interface IImgHeaderStreamReaderFactory
    {
        IImgHeaderReader Create(Stream stream, bool leaveOpen);
    }
}
