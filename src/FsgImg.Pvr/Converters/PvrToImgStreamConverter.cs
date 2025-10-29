using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions;
using FsgImg.Pvr.Abstractions.Interfaces;
using FsgImg.Pvr.Abstractions.Interfaces.Converters;
using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.Converters
{
    public class PvrToImgStreamConverter : IPvrToImgConverter
    {
        private readonly Stream _inputStream;
        private readonly Stream _outputStream;
        private readonly IPvrHeaderToImgHeaderConverter _converter;
        private readonly IPvrHeaderStreamReaderFactory _readerFactory;
        private readonly IImgHeaderStreamWriterFactory _writerFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public PvrToImgStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IPvrHeaderToImgHeaderConverter converter,
                                       IPvrHeaderStreamReaderFactory readerFactory,
                                       IImgHeaderStreamWriterFactory writerFactory)
            : this(inputStream,
                   outputStream,
                   converter,
                   readerFactory,
                   writerFactory,
                   false)
        {
        }

        public PvrToImgStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IPvrHeaderToImgHeaderConverter converter,
                                       IPvrHeaderStreamReaderFactory readerFactory,
                                       IImgHeaderStreamWriterFactory writerFactory,
                                       bool leaveOpen)
        {
            _inputStream = inputStream;
            _outputStream = outputStream;
            _converter = converter;
            _readerFactory = readerFactory;
            _writerFactory = writerFactory;
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

        public void Convert()
        {
            IPvrHeader pvrHeader;
            using (var reader = _readerFactory.Create(_inputStream, true))
            {
                pvrHeader = reader.Read();
            }

            var imgHeader = _converter.Convert(pvrHeader);

            using (var writer = _writerFactory.Create(_outputStream, true))
            {
                writer.Write(imgHeader);
            }

            _inputStream.Seek(-PvrConstants.PvrHeaderSize, SeekOrigin.Current);
            _inputStream.CopyTo(_outputStream);
        }

        public async Task ConvertAsync(CancellationToken cancellationToken = default)
        {
            IPvrHeader pvrHeader;
            using (var reader = _readerFactory.Create(_inputStream, true))
            {
                pvrHeader = await reader.ReadAsync();
            }

            var imgHeader = _converter.Convert(pvrHeader);

            using (var writer = _writerFactory.Create(_outputStream, true))
            {
                await writer.WriteAsync(imgHeader);
            }

            _inputStream.Seek(-PvrConstants.PvrHeaderSize, SeekOrigin.Current);
            await _inputStream.CopyToAsync(_outputStream, 81920, cancellationToken);
        }
    }
}
