using FsgImg.Abstractions.Interfaces;

namespace FsgImg.Dds.Abstractions.Interfaces
{
    public interface IDdsTexture : ITexture
    {
        uint Pitch { get; }
    }
}
