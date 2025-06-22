using FsgImg.Abstractions;
using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Factories;
using System;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FsgImg.Tests.IO
{
    public class ImgHeaderStreamWriterTest
    {
        protected virtual IImgHeaderStreamWriterFactory Factory { get; } =
            new ImgHeaderStreamWriterFactory(new ImgHeaderBufferWriterFactory());

        [Fact]
        public void Write_Xbox360Bc1_WritesImgHeaderToStream()
        {
            // Arrange
            var imgHeader = new ImgHeader
            {
                Width = 512,
                Height = 2048,
                Depth = 1,
                Pitch = 512,
                TextureFormat = ImgTextureFormat.Bc1,
                BcAlpha = 0,
                Game = ImgGame.ConsoleGhl,
                MipmapCount = 7,
                Platform = ImgPlatform.Xbox360
            };

            var actual = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
            try
            {
                using (var stream = new MemoryStream(actual, 0, ImgConstants.ImgHeaderSize))
                using (var writer = Factory.Create(stream, true))
                {
                    // Act
                    writer.Write(imgHeader);
                }

                // Assert
                var expected = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
                try
                {
                    expected[0] = 0x02;
                    expected[1] = 0x00;
                    expected[2] = 0x08;
                    expected[3] = 0x00;
                    expected[4] = 0x00;
                    expected[5] = 0x01;
                    expected[6] = 0x02;
                    expected[7] = 0x00;
                    expected[8] = 0x00;
                    expected[9] = 0x00;
                    expected[10] = 0x00;
                    expected[11] = 0x05;
                    expected[12] = 0x00;
                    expected[13] = 0x00;
                    expected[14] = 0x01;
                    expected[15] = 0x00;
                    expected[16] = 0x00;
                    expected[17] = 0x06;
                    expected[18] = 0x03;
                    expected[19] = 0x00;

                    Assert.Equal(new ReadOnlySpan<byte>(expected, 0, ImgConstants.ImgHeaderSize),
                                 new ReadOnlySpan<byte>(actual, 0, ImgConstants.ImgHeaderSize));
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(expected);
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(actual);
            }
        }

        [Fact]
        public async Task WriteAsync_Xbox360Bc1_WritesImgHeaderToStream()
        {
            // Arrange
            var imgHeader = new ImgHeader
            {
                Width = 512,
                Height = 2048,
                Depth = 1,
                Pitch = 512,
                TextureFormat = ImgTextureFormat.Bc1,
                BcAlpha = 0,
                Game = ImgGame.ConsoleGhl,
                MipmapCount = 7,
                Platform = ImgPlatform.Xbox360
            };

            var actual = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
            try
            {
                using (var stream = new MemoryStream(actual, 0, ImgConstants.ImgHeaderSize))
                using (var writer = Factory.Create(stream, true))
                {
                    // Act
                    await writer.WriteAsync(imgHeader);
                }

                // Assert
                var expected = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
                try
                {
                    expected[0] = 0x02;
                    expected[1] = 0x00;
                    expected[2] = 0x08;
                    expected[3] = 0x00;
                    expected[4] = 0x00;
                    expected[5] = 0x01;
                    expected[6] = 0x02;
                    expected[7] = 0x00;
                    expected[8] = 0x00;
                    expected[9] = 0x00;
                    expected[10] = 0x00;
                    expected[11] = 0x05;
                    expected[12] = 0x00;
                    expected[13] = 0x00;
                    expected[14] = 0x01;
                    expected[15] = 0x00;
                    expected[16] = 0x00;
                    expected[17] = 0x06;
                    expected[18] = 0x03;
                    expected[19] = 0x00;

                    Assert.Equal(new ReadOnlySpan<byte>(expected, 0, ImgConstants.ImgHeaderSize),
                                 new ReadOnlySpan<byte>(actual, 0, ImgConstants.ImgHeaderSize));
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(expected);
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(actual);
            }
        }
    }
}
