using FsgImg.Gtx.Abstractions.Enums;
using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class Gx2SurfaceByteArrayReader : IGx2SurfaceReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public Gx2SurfaceByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public Gx2SurfaceByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IGx2Surface Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var gx2Surface = new Gx2Surface();
            gx2Surface.Dimension = (Gx2SurfaceDimension)BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Width = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Height = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Depth = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.MipmapCount = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.TextureFormat = (Gx2SurfaceTextureFormat)BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.MsaaSampleCount = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Usage = (Gx2SurfaceUsageFlags)BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Size = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Offset = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.MipmapSize = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.MipmapOffset = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.TileMode = (Gx2SurfaceTileMode)BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Swizzle = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Alignment = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.Pitch = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            for (var i = 0; i < gx2Surface.MipmapOffsets.Length; i++)
            {
                gx2Surface.MipmapOffsets[i] = BinaryPrimitives.ReadUInt32BigEndian(span);
                span = span.Slice(sizeof(uint));
            }

            gx2Surface.FirstMipmapId = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.AvailableMipmapCount = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.FirstSliceId = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gx2Surface.AvailableSliceCount = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            for (var i = 0; i < gx2Surface.ColorChannels.Length; i++)
            {
                gx2Surface.ColorChannels[i] = (Gx2SurfaceColorChannel)span[0];
                span = span.Slice(sizeof(byte));
            }

            for (var i = 0; i < gx2Surface.TextureRegisters.Length; i++)
            {
                gx2Surface.TextureRegisters[i] = BinaryPrimitives.ReadUInt32BigEndian(span);
                span = span.Slice(sizeof(uint));
            }

            return gx2Surface;
        }

        public Task<IGx2Surface> ReadAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Read());
        }
    }
}
