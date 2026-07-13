using FsgImg.Abstractions;
using FsgImg.Gtx.Abstractions.Enums;
using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.Converters;
using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.Converters
{
    public class ImgToGtxStreamConverter : IImgToGtxConverter
    {
        private readonly Stream _inputStream;
        private readonly Stream _outputStream;
        private readonly IGx2SurfaceStreamReaderFactory _gx2SurfaceStreamReaderFactory;
        private readonly IGfx2HeaderStreamWriterFactory _gfx2HeaderStreamWriterFactory;
        private readonly IGtxBlockHeaderStreamWriterFactory _gtxBlockHeaderStreamWriterFactory;
        private readonly IGx2SurfaceStreamWriterFactory _gx2SurfaceStreamWriterFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public ImgToGtxStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IGx2SurfaceStreamReaderFactory gx2SurfaceStreamReaderFactory,
                                       IGfx2HeaderStreamWriterFactory gfx2HeaderStreamWriterFactory,
                                       IGtxBlockHeaderStreamWriterFactory gtxBlockHeaderStreamWriterFactory,
                                       IGx2SurfaceStreamWriterFactory gx2SurfaceStreamWriterFactory)
            : this(inputStream,
                   outputStream,
                   gx2SurfaceStreamReaderFactory,
                   gfx2HeaderStreamWriterFactory,
                   gtxBlockHeaderStreamWriterFactory,
                   gx2SurfaceStreamWriterFactory,
                   false)
        {
        }

        public ImgToGtxStreamConverter(Stream inputStream,
                                       Stream outputStream,
                                       IGx2SurfaceStreamReaderFactory gx2SurfaceStreamReaderFactory,
                                       IGfx2HeaderStreamWriterFactory gfx2HeaderStreamWriterFactory,
                                       IGtxBlockHeaderStreamWriterFactory gtxBlockHeaderStreamWriterFactory,
                                       IGx2SurfaceStreamWriterFactory gx2SurfaceStreamWriterFactory,
                                       bool leaveOpen)
        {
            _inputStream = inputStream;
            _outputStream = outputStream;
            _gx2SurfaceStreamReaderFactory = gx2SurfaceStreamReaderFactory;
            _gfx2HeaderStreamWriterFactory = gfx2HeaderStreamWriterFactory;
            _gtxBlockHeaderStreamWriterFactory = gtxBlockHeaderStreamWriterFactory;
            _gx2SurfaceStreamWriterFactory = gx2SurfaceStreamWriterFactory;
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
            _inputStream.Seek(ImgConstants.ImgHeaderSize, SeekOrigin.Current);

            IGx2Surface gx2Surface;
            using (var reader = _gx2SurfaceStreamReaderFactory.Create(_inputStream, true))
            {
                gx2Surface = reader.Read();
            }

            using (var gfx2HeaderWriter = _gfx2HeaderStreamWriterFactory.Create(_outputStream, true))
            {
                gfx2HeaderWriter.Write(CreateGfx2Header());
            }

            using (var gtxBlockHeaderWriter = _gtxBlockHeaderStreamWriterFactory.Create(_outputStream, true))
            {
                gtxBlockHeaderWriter.Write(CreateGx2SurfaceGtxBlockHeader());

                using (var gx2SurfaceWriter = _gx2SurfaceStreamWriterFactory.Create(_outputStream, true))
                {
                    gx2SurfaceWriter.Write(gx2Surface);
                }

                gtxBlockHeaderWriter.Write(CreateSwizzledImageGtxBlockHeader(gx2Surface));
            }

            _inputStream.CopyTo(_outputStream);
        }

        public async Task ConvertAsync(CancellationToken cancellationToken = default)
        {
            _inputStream.Seek(ImgConstants.ImgHeaderSize, SeekOrigin.Current);

            IGx2Surface gx2Surface;
            using (var reader = _gx2SurfaceStreamReaderFactory.Create(_inputStream, true))
            {
                gx2Surface = await reader.ReadAsync(cancellationToken);
            }

            using (var gfx2HeaderWriter = _gfx2HeaderStreamWriterFactory.Create(_outputStream, true))
            {
                await gfx2HeaderWriter.WriteAsync(CreateGfx2Header(), cancellationToken);
            }

            using (var gtxBlockHeaderWriter = _gtxBlockHeaderStreamWriterFactory.Create(_outputStream, true))
            {
                await gtxBlockHeaderWriter.WriteAsync(CreateGx2SurfaceGtxBlockHeader(), cancellationToken);

                using (var gx2SurfaceWriter = _gx2SurfaceStreamWriterFactory.Create(_outputStream, true))
                {
                    await gx2SurfaceWriter.WriteAsync(gx2Surface, cancellationToken);
                }

                await gtxBlockHeaderWriter.WriteAsync(CreateSwizzledImageGtxBlockHeader(gx2Surface), cancellationToken);
            }

            await _inputStream.CopyToAsync(_outputStream, 81920, cancellationToken);
        }

        private IGfx2Header CreateGfx2Header()
        {
            return new Gfx2Header
            {
                MajorVersion = 7,
                MinorVersion = 1,
                GpuVersion = 2,
                AlignMode = 1
            };
        }

        private IGtxBlockHeader CreateGx2SurfaceGtxBlockHeader()
        {
            return new Gfx2V7GtxBlockHeader
            {
                BlockType = Gfx2V7GtxBlockType.Gx2Surface,
                BlockSize = 0x9C
            };
        }

        private IGtxBlockHeader CreateSwizzledImageGtxBlockHeader(IGx2Surface gx2Surface)
        {
            return new Gfx2V7GtxBlockHeader
            {
                BlockType = Gfx2V7GtxBlockType.SwizzledImage,
                BlockSize = gx2Surface.Size + gx2Surface.MipmapSize
            };
        }
    }
}
