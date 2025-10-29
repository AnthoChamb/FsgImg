using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Converters;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Options;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Converters
{
    public class DdsToImgStreamConverter : IDdsToImgConverter
    {
        private readonly Stream _inputStream;
        private readonly Stream _outputStream;
        private readonly IDdsToImgHeaderConverter _converter;
        private readonly IDdsStreamReaderFactory _readerFactory;
        private readonly IImgHeaderStreamWriterFactory _writerFactory;
        private readonly IImgStreamFactory _imgStreamFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsToImgStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IDdsToImgHeaderConverter converter,
                                       IDdsStreamReaderFactory readerFactory,
                                       IImgHeaderStreamWriterFactory writerFactory,
                                       IImgStreamFactory imgStreamFactory)
            : this(inputStream,
                   outputStream,
                   converter,
                   readerFactory,
                   writerFactory,
                   imgStreamFactory,
                   false)
        {
        }

        public DdsToImgStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IDdsToImgHeaderConverter converter,
                                       IDdsStreamReaderFactory readerFactory,
                                       IImgHeaderStreamWriterFactory writerFactory,
                                       IImgStreamFactory imgStreamFactory,
                                       bool leaveOpen)
        {
            _inputStream = inputStream;
            _outputStream = outputStream;
            _converter = converter;
            _readerFactory = readerFactory;
            _writerFactory = writerFactory;
            _imgStreamFactory = imgStreamFactory;
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

        public void Convert(ConvertDdsToImgOptions options)
        {
            IDds dds;
            using (var reader = _readerFactory.Create(_inputStream, true))
            {
                dds = reader.Read();
            }

            var imgHeader = _converter.Convert(dds, options);

            using (var writer = _writerFactory.Create(_outputStream, true))
            {
                writer.Write(imgHeader);
            }

            var imgStream = _imgStreamFactory.Create(_outputStream, imgHeader);

            _inputStream.CopyTo(imgStream);
        }

        public async Task ConvertAsync(ConvertDdsToImgOptions options, CancellationToken cancellationToken = default)
        {
            IDds dds;
            using (var reader = _readerFactory.Create(_inputStream, true))
            {
                dds = await reader.ReadAsync(cancellationToken);
            }

            var imgHeader = _converter.Convert(dds, options);

            using (var writer = _writerFactory.Create(_outputStream, true))
            {
                await writer.WriteAsync(imgHeader, cancellationToken);
            }

            var imgStream = _imgStreamFactory.Create(_outputStream, imgHeader);

            await _inputStream.CopyToAsync(imgStream, 81920, cancellationToken);
        }
    }
}
