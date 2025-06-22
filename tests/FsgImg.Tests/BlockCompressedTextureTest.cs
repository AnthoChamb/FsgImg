using FsgImg.Dds.Abstractions;
using Xunit;

namespace FsgImg.Tests
{
    public class BlockCompressedTextureTest
    {
        [Theory]
        [InlineData(DdsConstants.DdsBlockWidth, DdsConstants.DdsBlockHeight, DdsConstants.DdsBc1BlockSize, 4)]
        [InlineData(DdsConstants.DdsBlockWidth, DdsConstants.DdsBlockHeight, DdsConstants.DdsBc3BlockSize, 8)]
        public void BitsPerPixel(uint blockWidth, uint blockHeight, uint blockSize, uint expected)
        {
            // Arrange
            var texture = new BlockCompressedTexture(512, 2048, 7, blockWidth, blockHeight, blockSize);

            // Act
            var actual = texture.BitsPerPixel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsUncompressed_IsFalse()
        {
            // Arrange
            var texture = new BlockCompressedTexture(512, 2048, 7, 4, 4, 8);

            // Act
            // Assert
            Assert.False(texture.IsUncompressed);
        }
    }
}
