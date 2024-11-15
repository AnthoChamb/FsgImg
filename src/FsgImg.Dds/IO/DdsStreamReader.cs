﻿using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.Exceptions;
using System.Buffers.Binary;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsStreamReader : IDdsReader
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderStreamReaderFactory _headerReaderFactory;
        private readonly IDdsHeaderDxt10StreamReaderFactory _headerDxt10ReaderFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsStreamReader(Stream stream, IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory)
            : this(stream, headerReaderFactory, headerDxt10ReaderFactory, false)
        {
        }

        public DdsStreamReader(Stream stream, IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory, bool leaveOpen)
        {
            _stream = stream;
            _headerReaderFactory = headerReaderFactory;
            _headerDxt10ReaderFactory = headerDxt10ReaderFactory;
            _leaveOpen = leaveOpen;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (!_leaveOpen)
                {
                    _stream.Dispose();
                }
                _disposed = true;
            }
        }

        public IDds Read()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[sizeof(uint)];
            // TODO: Use ReadExactly when available
            var bytesRead = _stream.Read(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            var magic = BinaryPrimitives.ReadUInt32LittleEndian(buffer);
            if (magic != DdsConstants.DdsMagic)
            {
                throw new InvalidDdsMagicException(magic);
            }

            var dds = new Dds();
            dds.Magic = magic;

            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                dds.Header = headerReader.Read();
            }

            if (dds.Header.PixelFormat.FourCc == DdsFourCc.Dx10)
            {
                using (var headerDxt10Reader = _headerDxt10ReaderFactory.Create(_stream, true))
                {
                    dds.HeaderDxt10 = headerDxt10Reader.Read();
                }
            }

            return dds;
        }

        public async Task<IDds> ReadAsync()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[sizeof(uint)];
            // TODO: Use ReadExactlyAsync when available
            var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            var magic = BinaryPrimitives.ReadUInt32LittleEndian(buffer);
            if (magic != DdsConstants.DdsMagic)
            {
                throw new InvalidDdsMagicException(magic);
            }

            var dds = new Dds();
            dds.Magic = magic;

            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                dds.Header = await headerReader.ReadAsync();
            }

            if (dds.Header.PixelFormat.FourCc == DdsFourCc.Dx10)
            {
                using (var headerDxt10Reader = _headerDxt10ReaderFactory.Create(_stream, true))
                {
                    dds.HeaderDxt10 = await headerDxt10Reader.ReadAsync();
                }
            }

            return dds;
        }
    }
}
