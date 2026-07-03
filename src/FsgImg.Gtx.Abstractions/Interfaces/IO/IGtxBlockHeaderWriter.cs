using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Abstractions.Interfaces.IO
{
    public interface IGtxBlockHeaderWriter : IDisposable
    {
        void Write(IGtxBlockHeader gtxBlockHeader);
        Task WriteAsync(IGtxBlockHeader gtxBlockHeader, CancellationToken cancellationToken = default);
    }
}
