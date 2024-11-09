using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsWriter : IDisposable
    {
        void Write(IDds dds);
        Task WriteAsync(IDds dds);
    }
}
