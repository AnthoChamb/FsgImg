using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Abstractions.Interfaces.IO
{
    public interface IGfx2HeaderReader : IDisposable
    {
        IGfx2Header Read();
        Task<IGfx2Header> ReadAsync(CancellationToken cancellationToken = default);
    }
}
