using System;
using System.Threading.Tasks;

namespace FsgImg.Core.Interfaces.IO
{
    public interface IImgHeaderWriter : IDisposable
    {
        Task WriteAsync(IImgHeader imgHeader);
    }
}
