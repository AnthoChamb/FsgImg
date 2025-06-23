using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsHeaderDxt10Reader : IDisposable
    {
        IDdsHeaderDxt10 Read();
        Task<IDdsHeaderDxt10> ReadAsync(CancellationToken cancellationToken = default);
    }
}
