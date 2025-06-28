using FsgImg.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Options;

namespace FsgImg.Dds.Abstractions.Interfaces.Converters
{
    public interface IDdsToImgHeaderConverter
    {
        IImgHeader ConvertFrom(IDds dds, ConvertFromOptions options);
    }
}
