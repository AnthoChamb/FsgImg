using FsgImg.Dds.Abstractions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.Converters
{
    public interface IDdsToImgConverter
    {
        void ConvertFrom(ConvertFromOptions options);
        Task ConvertFromAsync(ConvertFromOptions options, CancellationToken cancellationToken = default);
    }
}
