using System;
using System.Threading.Tasks;

namespace FsgImg.Core.Interfaces
{
    public interface IImgHeaderWriter : IDisposable
    {
        Task WriteAsync(IImgHeader imgHeader);
    }
}
