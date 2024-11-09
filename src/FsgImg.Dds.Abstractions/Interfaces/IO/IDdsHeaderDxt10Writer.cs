using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsHeaderDxt10Writer : IDisposable
    {
        void Write(IDdsHeaderDxt10 ddsHeaderDxt10);
        Task WriteAsync(IDdsHeaderDxt10 ddsHeaderDxt10);
    }
}
