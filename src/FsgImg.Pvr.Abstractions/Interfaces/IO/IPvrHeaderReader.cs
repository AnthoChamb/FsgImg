using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Abstractions.Interfaces.IO
{
    public interface IPvrHeaderReader
    {
        IPvrHeader Read();
        Task<IPvrHeader> ReadAsync(CancellationToken cancellationToken = default);
    }
}
