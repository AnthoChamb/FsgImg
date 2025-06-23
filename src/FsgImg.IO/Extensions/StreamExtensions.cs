using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.IO.Extensions
{
    public static class StreamExtensions
    {
        public static void ReadExactly(this Stream stream, byte[] buffer, int offset, int count)
        {
            var totalRead = 0;
            while (totalRead < count)
            {
                var read = stream.Read(buffer, offset + totalRead, count - totalRead);

                if (read == 0)
                {
                    ThrowHelper.ThrowEndOfStreamException();
                }

                totalRead += read;
            }
        }

        public static async Task ReadExactlyAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken = default)
        {
            var totalRead = 0;
            while (totalRead < count)
            {
                var read = await stream.ReadAsync(buffer, offset + totalRead, count - totalRead, cancellationToken).ConfigureAwait(false);

                if (read == 0)
                {
                    ThrowHelper.ThrowEndOfStreamException();
                }

                totalRead += read;
            }
        }
    }
}
