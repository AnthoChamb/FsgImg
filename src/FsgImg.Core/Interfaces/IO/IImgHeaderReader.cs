using System;
using System.Threading.Tasks;

namespace FsgImg.Core.Interfaces.IO
{
    public interface IImgHeaderReader : IDisposable
    {
        IImgHeader Read();
        Task<IImgHeader> ReadAsync();
    }
}
