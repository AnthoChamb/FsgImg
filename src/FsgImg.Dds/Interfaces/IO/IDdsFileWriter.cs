using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Interfaces.IO
{
    public interface IDdsFileWriter : IDisposable
    {
        void Write(IDdsFile ddsFile);
        Task WriteAsync(IDdsFile ddsFile);
    }
}
