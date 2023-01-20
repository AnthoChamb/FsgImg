using FsgImg.IO.Interfaces;

namespace FsgImg.IO
{
    public class ReverseShortBufferTransform : IBufferTransform
    {
        public void Transform(byte[] buffer, int offset, int count)
        {
            for (var i = 0; i + 1 < count; i += 2)
            {
                (buffer[offset + i], buffer[offset + i + 1]) = (buffer[offset + i + 1], buffer[offset + i]);
            }
        }
    }
}
