using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsReader : IDisposable
    {
        IDds Read();
        Task<IDds> ReadAsync(CancellationToken cancellationToken = default);
    }
}
