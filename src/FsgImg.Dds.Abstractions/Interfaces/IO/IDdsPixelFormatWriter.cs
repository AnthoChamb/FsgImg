using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsPixelFormatWriter : IDisposable
    {
        void Write(IDdsPixelFormat ddsPixelFormat);
        Task WriteAsync(IDdsPixelFormat ddsPixelFormat);
    }
}
