using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Interfaces.IO
{
    public interface IDdsHeaderReader : IDisposable
    {
        IDdsHeader Read();
        Task<IDdsHeader> ReadAsync();
    }
}
