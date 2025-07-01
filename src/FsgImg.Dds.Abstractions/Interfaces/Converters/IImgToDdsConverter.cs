using FsgImg.Dds.Abstractions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.Converters
{
    public interface IImgToDdsConverter : IDisposable
    {
        void ConvertTo(ConvertToOptions options);
        Task ConvertToAsync(ConvertToOptions options, CancellationToken cancellationToken = default);
    }
}
