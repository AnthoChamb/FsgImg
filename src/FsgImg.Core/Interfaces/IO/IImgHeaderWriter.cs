using System;
using System.Threading.Tasks;

namespace FsgImg.Core.Interfaces.IO
{
    public interface IImgHeaderWriter : IDisposable
    {
        void Write(IImgHeader imgHeader);
        Task WriteAsync(IImgHeader imgHeader);
    }
}
