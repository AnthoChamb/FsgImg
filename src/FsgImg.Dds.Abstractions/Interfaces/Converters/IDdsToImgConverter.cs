using FsgImg.Dds.Abstractions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.Converters
{
    public interface IDdsToImgConverter : IDisposable
    {
        void Convert(ConvertDdsToImgOptions options);
        Task ConvertAsync(ConvertDdsToImgOptions options, CancellationToken cancellationToken = default);
    }
}
