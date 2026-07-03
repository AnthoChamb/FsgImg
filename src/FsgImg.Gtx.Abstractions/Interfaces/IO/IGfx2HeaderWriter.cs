using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Abstractions.Interfaces.IO
{
    public interface IGfx2HeaderWriter : IDisposable
    {
        void Write(IGfx2Header gfx2Header);
        Task WriteAsync(IGfx2Header gfx2Header, CancellationToken cancellationToken = default);
    }
}
