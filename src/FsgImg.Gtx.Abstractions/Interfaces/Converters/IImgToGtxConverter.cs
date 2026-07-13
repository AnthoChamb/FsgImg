using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Abstractions.Interfaces.Converters
{
    public interface IImgToGtxConverter : IDisposable
    {
        void Convert();
        Task ConvertAsync(CancellationToken cancellationToken = default);
    }
}