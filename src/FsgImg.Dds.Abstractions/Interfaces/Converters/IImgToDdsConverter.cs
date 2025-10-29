using FsgImg.Dds.Abstractions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.Converters
{
    public interface IImgToDdsConverter : IDisposable
    {
        void Convert(ConvertImgToDdsOptions options);
        Task ConvertAsync(ConvertImgToDdsOptions options, CancellationToken cancellationToken = default);
    }
}
