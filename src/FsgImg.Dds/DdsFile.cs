using FsgImg.Dds.Interfaces;

namespace FsgImg.Dds
{
    public class DdsFile : IDdsFile
    {
        public uint Magic { get; set; } = DdsConstants.DdsFileMagic;
        public IDdsHeader Header { get; set; }
        public IDdsHeaderDxt10 HeaderDxt10 { get; set; }
    }
}
