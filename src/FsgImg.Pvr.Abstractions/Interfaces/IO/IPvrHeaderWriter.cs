using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Abstractions.Interfaces.IO
{
    public interface IPvrHeaderWriter : IDisposable
    {
        void Write(IPvrHeader pvrHeader);
        Task WriteAsync(IPvrHeader pvrHeader, CancellationToken cancellationToken = default);
    }
}
