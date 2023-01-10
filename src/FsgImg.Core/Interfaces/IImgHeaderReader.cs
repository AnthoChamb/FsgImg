using System;
using System.Threading.Tasks;

namespace FsgImg.Core.Interfaces
{
    public interface IImgHeaderReader : IDisposable
    {
        Task<IImgHeader> ReadAsync();
    }
}
