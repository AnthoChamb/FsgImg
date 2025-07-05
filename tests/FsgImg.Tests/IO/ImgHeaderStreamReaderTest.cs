using FsgImg.Abstractions;
using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Factories;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FsgImg.Tests.IO
{
    public class ImgHeaderStreamReaderTest
    {
        protected virtual IImgHeaderStreamReaderFactory Factory { get; } =
            new ImgHeaderStreamReaderFactory(new ImgHeaderByteArrayReaderFactory(new ImgHeaderFactory()));

        [Fact]
        public void Read_Xbox360Bc1_ReturnsImgHeader()
        {
            // Arrange
            IImgHeader imgHeader;
            var buffer = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
            try
            {
                buffer[0] = 0x02;
                buffer[1] = 0x00;
                buffer[2] = 0x08;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x01;
                buffer[6] = 0x02;
                buffer[7] = 0x00;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x00;
                buffer[11] = 0x05;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x01;
                buffer[15] = 0x00;
                buffer[16] = 0x00;
                buffer[17] = 0x06;
                buffer[18] = 0x03;
                buffer[19] = 0x00;

                using var stream = new MemoryStream(buffer, 0, ImgConstants.ImgHeaderSize, false);
                using var reader = Factory.Create(stream, true);

                // Act
                imgHeader = reader.Read();
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            // Assert
            Assert.Equal(512, imgHeader.Width);
            Assert.Equal(2048, imgHeader.Height);
            Assert.Equal(1, imgHeader.Depth);
            Assert.Equal(512, imgHeader.Pitch);
            Assert.Equal(ImgTextureFormat.Bc1, imgHeader.TextureFormat);
            Assert.Equal(0, imgHeader.BcAlpha);
            Assert.Equal(ImgGame.ConsoleGhl, imgHeader.Game);
            Assert.Equal(7, imgHeader.MipmapCount);
            Assert.Equal(ImgPlatform.Xbox360, imgHeader.Platform);
        }

        [Fact]
        public async Task ReadAsync_Xbox360Bc1_ReturnsImgHeader()
        {
            // Arrange
            IImgHeader imgHeader;
            var buffer = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
            try
            {
                buffer[0] = 0x02;
                buffer[1] = 0x00;
                buffer[2] = 0x08;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x01;
                buffer[6] = 0x02;
                buffer[7] = 0x00;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x00;
                buffer[11] = 0x05;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x01;
                buffer[15] = 0x00;
                buffer[16] = 0x00;
                buffer[17] = 0x06;
                buffer[18] = 0x03;
                buffer[19] = 0x00;

                using var stream = new MemoryStream(buffer, 0, ImgConstants.ImgHeaderSize, false);
                using var reader = Factory.Create(stream, true);

                // Act
                imgHeader = await reader.ReadAsync();
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            // Assert
            Assert.Equal(512, imgHeader.Width);
            Assert.Equal(2048, imgHeader.Height);
            Assert.Equal(1, imgHeader.Depth);
            Assert.Equal(512, imgHeader.Pitch);
            Assert.Equal(ImgTextureFormat.Bc1, imgHeader.TextureFormat);
            Assert.Equal(0, imgHeader.BcAlpha);
            Assert.Equal(ImgGame.ConsoleGhl, imgHeader.Game);
            Assert.Equal(7, imgHeader.MipmapCount);
            Assert.Equal(ImgPlatform.Xbox360, imgHeader.Platform);
        }
    }
}
