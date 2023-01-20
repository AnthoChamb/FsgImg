using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Interfaces.IO
{
    public interface IDdsHeaderDxt10Reader : IDisposable
    {
        IDdsHeaderDxt10 Read();
        Task<IDdsHeaderDxt10> ReadAsync();
    }
}
