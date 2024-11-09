using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Abstractions.Interfaces.IO
{
    public interface IDdsHeaderReader : IDisposable
    {
        IDdsHeader Read();
        Task<IDdsHeader> ReadAsync();
    }
}
