using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Abstractions.Interfaces.IO
{
    public interface IPvrHeaderReader : IDisposable
    {
        IPvrHeader Read();
        Task<IPvrHeader> ReadAsync(CancellationToken cancellationToken = default);
    }
}
