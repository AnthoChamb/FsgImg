using FsgImg.Dds.Enums;
using FsgImg.Dds.Interfaces;

namespace FsgImg.Dds
{
    public class DdsHeaderDxt10 : IDdsHeaderDxt10
    {
        public DxgiFormat DxgiFormat { get; set; }
        public DdsDimension Dimension { get; set; } = DdsDimension.Texture2D;
        public DdsMiscFlags MiscFlags { get; set; }
        public uint ArraySize { get; set; } = 1;
        public DdsMiscFlags2 MiscFlags2 { get; set; }
    }
}
