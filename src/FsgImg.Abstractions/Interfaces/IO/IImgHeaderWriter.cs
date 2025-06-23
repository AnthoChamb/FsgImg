using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Abstractions.Interfaces.IO
{
    public interface IImgHeaderWriter : IDisposable
    {
        void Write(IImgHeader imgHeader);
        Task WriteAsync(IImgHeader imgHeader, CancellationToken cancellationToken = default);
    }
}
