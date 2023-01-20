using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Interfaces.IO
{
    public interface IDdsPixelFormatWriter : IDisposable
    {
        void Write(IDdsPixelFormat ddsPixelFormat);
        Task WriteAsync(IDdsPixelFormat ddsPixelFormat);
    }
}
