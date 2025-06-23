using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Abstractions.Interfaces.IO
{
    public interface IImgHeaderReader : IDisposable
    {
        IImgHeader Read();
        Task<IImgHeader> ReadAsync(CancellationToken cancellationToken = default);
    }
}
