namespace FsgImg.Core.Interfaces
{
    public interface IImgHeaderBufferReaderFactory
    {
        IImgHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
