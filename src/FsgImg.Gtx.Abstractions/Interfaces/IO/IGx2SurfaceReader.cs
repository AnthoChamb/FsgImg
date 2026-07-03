using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Abstractions.Interfaces.IO
{
    public interface IGx2SurfaceReader : IDisposable
    {
        IGx2Surface Read();
        Task<IGx2Surface> ReadAsync(CancellationToken cancellationToken = default);
    }
}
