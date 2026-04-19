namespace FsgImg.Gtx.Abstractions.Interfaces
{
    public interface IGfx2Header
    {
        uint Magic { get; set; }
        uint Size { get; set; }
        uint MajorVersion { get; set; }
        uint MinorVersion { get; set; }
        uint GpuVersion { get; set; }
        uint AlignMode { get; set; }
        uint Reserved { get; set; }
        uint Reserved2 { get; set; }
    }
}
