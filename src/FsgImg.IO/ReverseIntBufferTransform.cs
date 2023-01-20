using FsgImg.IO.Interfaces;

namespace FsgImg.IO
{
    public class ReverseIntBufferTransform : IBufferTransform
    {
        public void Transform(byte[] buffer, int offset, int count)
        {
            for (var i = 0; i + 3 < count; i += 4)
            {
                (buffer[offset + i], buffer[offset + i + 1], buffer[offset + i + 2], buffer[offset + i + 3]) = (buffer[offset + i + 3], buffer[offset + i + 2], buffer[offset + i + 1], buffer[offset + i]);
            }
        }
    }
}
