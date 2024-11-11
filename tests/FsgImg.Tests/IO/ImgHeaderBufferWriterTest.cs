using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions;
using FsgImg.IO;
using System.Buffers;
using Xunit;
using System;

namespace FsgImg.Tests.IO
{
    public class ImgHeaderBufferWriterTest
    {
        [Fact]
        public void Write_Xbox360Bc1_WritesImgHeaderToBuffer()
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
                using var writer = new ImgHeaderBufferWriter(actual, 0, ImgConstants.ImgHeaderSize);

                // Act
                writer.Write(imgHeader);

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

                    Assert.True(new ReadOnlySpan<byte>(expected, 0, ImgConstants.ImgHeaderSize)
                        .SequenceEqual(new ReadOnlySpan<byte>(actual, 0, ImgConstants.ImgHeaderSize)));
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
