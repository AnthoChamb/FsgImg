using System;
using System.Threading.Tasks;

namespace FsgImg.Core.Interfaces.IO
{
    public interface IImgHeaderReader : IDisposable
    {
        Task<IImgHeader> ReadAsync();
    }
}
