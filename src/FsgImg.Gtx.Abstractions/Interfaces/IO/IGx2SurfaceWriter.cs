using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Abstractions.Interfaces.IO
{
    public interface IGx2SurfaceWriter : IDisposable
    {
        void Write(IGx2Surface gx2Surface);
        Task WriteAsync(IGx2Surface gx2Surface, CancellationToken cancellationToken = default);
    }
}
