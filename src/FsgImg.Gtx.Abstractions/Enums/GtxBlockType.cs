namespace FsgImg.Gtx.Abstractions.Enums
{
    public enum GtxBlockType : uint
    {
        None = 0x00,
        EndOfFile = 0x01,
        Padding = 0x02,
        VertexShaderHeader = 0x03,
        VertexShaderProgram = 0x05,
        PixelShaderHeader = 0x06,
        PixelShaderProgram = 0x07,
        GeometryShaderHeader = 0x08,
        GeometryShaderProgram = 0x09
    }
}
