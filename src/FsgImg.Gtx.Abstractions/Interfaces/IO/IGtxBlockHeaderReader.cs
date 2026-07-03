using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Abstractions.Interfaces.IO
{
    public interface IGtxBlockHeaderReader : IDisposable
    {
        IGtxBlockHeader Read();
        Task<IGtxBlockHeader> ReadAsync(CancellationToken cancellationToken = default);
    }
}
