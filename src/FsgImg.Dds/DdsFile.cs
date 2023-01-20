using FsgImg.Dds.Interfaces;

namespace FsgImg.Dds
{
    public class DdsFile : IDdsFile
    {
        public uint Magic { get; set; } = 0x20_53_44_44u;
        public IDdsHeader Header { get; set; }
        public IDdsHeaderDxt10 HeaderDxt10 { get; set; }
    }
}
