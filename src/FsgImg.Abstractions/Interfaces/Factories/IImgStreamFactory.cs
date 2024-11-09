using System.IO;

namespace FsgImg.Abstractions.Interfaces.Factories
{
    public interface IImgStreamFactory
    {
        Stream Create(Stream stream, IImgHeader imgHeader);
    }
}
