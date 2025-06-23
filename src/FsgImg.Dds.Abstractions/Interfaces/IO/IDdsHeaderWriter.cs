using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsHeaderWriter : IDisposable
    {
        void Write(IDdsHeader ddsHeader);
        Task WriteAsync(IDdsHeader ddsHeader, CancellationToken cancellationToken = default);
    }
}
