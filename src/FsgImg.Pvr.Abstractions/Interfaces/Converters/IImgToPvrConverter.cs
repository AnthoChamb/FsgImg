using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Abstractions.Interfaces.Converters
{
    public interface IImgToPvrConverter : IDisposable
    {
        void Convert();
        Task ConvertAsync(CancellationToken cancellationToken = default);
    }
}
