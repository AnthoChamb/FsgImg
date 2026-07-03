using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class Gx2SurfaceByteArrayWriter : IGx2SurfaceWriter
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public Gx2SurfaceByteArrayWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public Gx2SurfaceByteArrayWriter(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IGx2Surface gx2Surface)
        {
            var span = new Span<byte>(_buffer, _offset, _count);

            BinaryPrimitives.WriteUInt32BigEndian(span, (uint)gx2Surface.Dimension);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Width);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Height);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Depth);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.MipmapCount);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, (uint)gx2Surface.TextureFormat);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.MsaaSampleCount);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, (uint)gx2Surface.Usage);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Size);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Offset);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.MipmapSize);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.MipmapOffset);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, (uint)gx2Surface.TileMode);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Swizzle);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Alignment);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.Pitch);
            span = span.Slice(sizeof(uint));

            for (var i = 0; i < gx2Surface.MipmapOffsets.Length; i++)
            {
                BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.MipmapOffsets[i]);
                span = span.Slice(sizeof(uint));
            }

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.FirstMipmapId);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.AvailableMipmapCount);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.FirstSliceId);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.AvailableSliceCount);
            span = span.Slice(sizeof(uint));

            for (var i = 0; i < gx2Surface.ColorChannels.Length; i++)
            {
                span[0] = (byte)gx2Surface.ColorChannels[i];
                span = span.Slice(sizeof(byte));
            }

            for (var i = 0; i < gx2Surface.TextureRegisters.Length; i++)
            {
                BinaryPrimitives.WriteUInt32BigEndian(span, gx2Surface.TextureRegisters[i]);
                span = span.Slice(sizeof(uint));
            }
        }

        public Task WriteAsync(IGx2Surface gx2Surface, CancellationToken cancellationToken = default)
        {
            Write(gx2Surface);
            return Task.CompletedTask;
        }
    }
}
