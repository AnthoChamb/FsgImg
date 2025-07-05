using FsgImg.Abstractions;
using FsgImg.Pvr.Abstractions.Interfaces.Converters;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Converters
{
    public class ImgToPvrStreamConverter : IImgToPvrConverter
    {
        private readonly Stream _inputStream;
        private readonly Stream _outputStream;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public ImgToPvrStreamConverter(Stream inputStream, Stream outputStream) : this(inputStream, outputStream, false)
        {
        }

        public ImgToPvrStreamConverter(Stream inputStream, Stream outputStream, bool leaveOpen)
        {
            _inputStream = inputStream;
            _outputStream = outputStream;
            _leaveOpen = leaveOpen;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (!_leaveOpen)
                {
                    _inputStream.Dispose();
                    _outputStream.Dispose();
                }
                _disposed = true;
            }
        }

        public void ConvertTo()
        {
            _inputStream.Seek(ImgConstants.ImgHeaderSize, SeekOrigin.Current);
            _inputStream.CopyTo(_outputStream);
        }

        public async Task ConvertToAsync(CancellationToken cancellationToken = default)
        {
            _inputStream.Seek(ImgConstants.ImgHeaderSize, SeekOrigin.Current);
            await _inputStream.CopyToAsync(_outputStream, 81920, cancellationToken);
        }
    }
}
