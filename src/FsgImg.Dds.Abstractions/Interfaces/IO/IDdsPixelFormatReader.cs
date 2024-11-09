using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsPixelFormatReader : IDisposable
    {
        IDdsPixelFormat Read();
        Task<IDdsPixelFormat> ReadAsync();
    }
}
