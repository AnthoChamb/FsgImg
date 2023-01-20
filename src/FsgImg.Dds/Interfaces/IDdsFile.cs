namespace FsgImg.Dds.Interfaces
{
    public interface IDdsFile
    {
        uint Magic { get; set; }
        IDdsHeader Header { get; set; }
        IDdsHeaderDxt10 HeaderDxt10 { get; set; }
    }
}
