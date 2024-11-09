namespace FsgImg.Abstractions.Interfaces
{
    public interface IBufferTransform
    {
        void Transform(byte[] buffer, int offset, int count);
    }
}
