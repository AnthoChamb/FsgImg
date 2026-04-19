namespace FsgImg.Gtx.Abstractions.Enums
{
    public enum Gfx2V6GtxBlockType : uint
    {
        None = GtxBlockType.None,
        EndOfFile = GtxBlockType.EndOfFile,
        Padding = GtxBlockType.Padding,
        VertexShaderHeader = GtxBlockType.VertexShaderHeader,
        VertexShaderProgram = GtxBlockType.VertexShaderProgram,
        PixelShaderHeader = GtxBlockType.PixelShaderHeader,
        PixelShaderProgram = GtxBlockType.PixelShaderProgram,
        GeometryShaderHeader = GtxBlockType.GeometryShaderHeader,
        GeometryShaderProgram = GtxBlockType.GeometryShaderProgram,
        Gx2Surface = 0x0A,
        SwizzledImage = 0x0B,
        SwizzledMipmap = 0x0C,
        GeometryCopyShaderProgram = 0x0D,
        Reserved = 0x0E,
        Reserved2 = 0x0F
    }
}
