using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.Converters;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Options;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.Converters
{
    public class ImgToDdsStreamConverter : IImgToDdsConverter
    {
        private readonly Stream _inputStream;
        private readonly Stream _outputStream;
        private readonly IImgHeaderToDdsConverter _converter;
        private readonly IImgHeaderStreamReaderFactory _readerFactory;
        private readonly IDdsStreamWriterFactory _writerFactory;
        private readonly IImgStreamFactory _imgStreamFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public ImgToDdsStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IImgHeaderToDdsConverter converter,
                                       IImgHeaderStreamReaderFactory readerFactory,
                                       IDdsStreamWriterFactory writerFactory,
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

        public ImgToDdsStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IImgHeaderToDdsConverter converter,
                                       IImgHeaderStreamReaderFactory readerFactory,
                                       IDdsStreamWriterFactory writerFactory,
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

        public void Convert(ConvertImgToDdsOptions options)
        {
            IImgHeader imgHeader;
            using (var reader = _readerFactory.Create(_inputStream, true))
            {
                imgHeader = reader.Read();
            }

            if (imgHeader.Platform == ImgPlatform.Unknown && options.Platform.HasValue)
            {
                imgHeader.Platform = (ImgPlatform)options.Platform.Value;
            }

            var ddsFile = _converter.Convert(imgHeader);

            using (var writer = _writerFactory.Create(_outputStream, true))
            {
                writer.Write(ddsFile);
            }

            var imgStream = _imgStreamFactory.Create(_inputStream, imgHeader);

            imgStream.CopyTo(_outputStream);
        }

        public async Task ConvertAsync(ConvertImgToDdsOptions options, CancellationToken cancellationToken = default)
        {
            IImgHeader imgHeader;
            using (var reader = _readerFactory.Create(_inputStream, true))
            {
                imgHeader = await reader.ReadAsync(cancellationToken);
            }

            if (imgHeader.Platform == ImgPlatform.Unknown && options.Platform.HasValue)
            {
                imgHeader.Platform = (ImgPlatform)options.Platform.Value;
            }

            var ddsFile = _converter.Convert(imgHeader);

            using (var writer = _writerFactory.Create(_outputStream, true))
            {
                await writer.WriteAsync(ddsFile, cancellationToken);
            }

            var imgStream = _imgStreamFactory.Create(_inputStream, imgHeader);

            await imgStream.CopyToAsync(_outputStream, 81920, cancellationToken);
        }
    }
}
