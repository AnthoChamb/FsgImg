using System;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Abstractions.Interfaces.Converters
{
    public interface IPvrToImgConverter : IDisposable
    {
        void ConvertFrom();
        Task ConvertFromAsync(CancellationToken cancellationToken = default);
    }
}
