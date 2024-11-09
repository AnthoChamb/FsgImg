using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;

namespace FsgImg.Dds
{
    public class Dds : IDds
    {
        public uint Magic { get; set; } = DdsConstants.DdsMagic;
        public IDdsHeader Header { get; set; }
        public IDdsHeaderDxt10 HeaderDxt10 { get; set; }
    }
}
