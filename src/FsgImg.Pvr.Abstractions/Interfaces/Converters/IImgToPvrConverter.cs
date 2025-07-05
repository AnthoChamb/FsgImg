using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Abstractions.Interfaces.Converters
{
    public interface IImgToPvrConverter : IDisposable
    {
        void ConvertTo();
        Task ConvertToAsync(CancellationToken cancellationToken = default);
    }
}
