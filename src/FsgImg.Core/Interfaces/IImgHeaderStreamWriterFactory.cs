using System.IO;

namespace FsgImg.Core.Interfaces
{
    public interface IImgHeaderStreamWriterFactory
    {
        IImgHeaderWriter Create(Stream stream, bool leaveOpen);
    }
}
