namespace FsgImg.Gtx.Abstractions.Enums
{
    public enum Gfx2V7GtxBlockType : uint
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
        GeometryCopyShaderProgram = 0x0A,
        Gx2Surface = 0x0B,
        SwizzledImage = 0x0C,
        SwizzledMipmap = 0x0D,
        ComputeShaderHeader = 0x0E,
        ComputeShaderProgram = 0x0F
    }
}
