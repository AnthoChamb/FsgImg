using FsgImg.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Abstractions.Interfaces.Factories
{
    public interface IImgHeaderStreamWriterFactory
    {
        IImgHeaderWriter Create(Stream stream, bool leaveOpen);
    }
}
