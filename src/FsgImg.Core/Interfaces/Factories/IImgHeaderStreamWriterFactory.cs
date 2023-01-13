using FsgImg.Core.Interfaces.IO;
using System.IO;

namespace FsgImg.Core.Interfaces.Factories
{
    public interface IImgHeaderStreamWriterFactory
    {
        IImgHeaderWriter Create(Stream stream, bool leaveOpen);
    }
}
