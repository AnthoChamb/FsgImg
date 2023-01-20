using FsgImg.Dds.Enums;

namespace FsgImg.Dds.Interfaces
{
    public interface IDdsHeaderDxt10
    {
        DxgiFormat DxgiFormat { get; set; }
        DdsDimension Dimension { get; set; }
        DdsMiscFlags MiscFlags { get; set; }
        uint ArraySize { get; set; }
        DdsMiscFlags2 MiscFlags2 { get; set; }
    }
}
