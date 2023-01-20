using System.IO;

namespace FsgImg.Core.Interfaces.Factories
{
    public interface IImgStreamFactory
    {
        Stream Create(Stream stream, IImgHeader imgHeader);
    }
}
