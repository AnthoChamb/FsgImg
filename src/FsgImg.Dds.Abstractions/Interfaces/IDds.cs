namespace FsgImg.Dds.Abstractions.Interfaces
{
    public interface IDds
    {
        uint Magic { get; set; }
        IDdsHeader Header { get; set; }
        IDdsHeaderDxt10 HeaderDxt10 { get; set; }
    }
}
