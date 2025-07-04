﻿using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderDxt10ByteArrayWriter : IDdsHeaderDxt10Writer
    {
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public DdsHeaderDxt10ByteArrayWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public DdsHeaderDxt10ByteArrayWriter(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IDdsHeaderDxt10 ddsHeaderDxt10)
        {
            var span = new Span<byte>(_buffer, _offset, _count);
            var start = 0;

            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsHeaderDxt10.DxgiFormat);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsHeaderDxt10.Dimension);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsHeaderDxt10.MiscFlags);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeaderDxt10.ArraySize);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsHeaderDxt10.MiscFlags2);
        }

        public Task WriteAsync(IDdsHeaderDxt10 ddsHeaderDxt10, CancellationToken cancellationToken = default)
        {
            Write(ddsHeaderDxt10);
            return Task.CompletedTask;
        }
    }
}
