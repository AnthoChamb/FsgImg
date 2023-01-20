using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Interfaces.IO
{
    public interface IDdsFileReader : IDisposable
    {
        IDdsFile Read();
        Task<IDdsFile> ReadAsync();
    }
}
