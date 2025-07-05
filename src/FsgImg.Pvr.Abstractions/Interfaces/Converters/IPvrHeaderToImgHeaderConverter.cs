using FsgImg.Abstractions.Interfaces;

namespace FsgImg.Pvr.Abstractions.Interfaces.Converters
{
    public interface IPvrHeaderToImgHeaderConverter
    {
        IImgHeader ConvertFrom(IPvrHeader pvrHeader);
    }
}
