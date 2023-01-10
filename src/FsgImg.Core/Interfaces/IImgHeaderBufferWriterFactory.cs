namespace FsgImg.Core.Interfaces
{
    public interface IImgHeaderBufferWriterFactory
    {
        IImgHeaderWriter Create(byte[] buffer, int offset, int count);
    }
}
