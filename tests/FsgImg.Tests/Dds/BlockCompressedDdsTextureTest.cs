using FsgImg.Dds;
using FsgImg.Dds.Abstractions;
using Xunit;

namespace FsgImg.Tests.Dds
{
    public class BlockCompressedDdsTextureTest
    {
        [Theory]
        [InlineData(512, 2048, 7, DdsConstants.DdsBlockWidth, DdsConstants.DdsBlockHeight, DdsConstants.DdsBc1BlockSize, 1024)]
        public void Pitch(uint width,
                          uint height,
                          uint mipmapCount,
                          uint blockWidth,
                          uint blockHeight,
                          uint blockSize,
                          uint expected)
        {
            // Arrange
            var texture = new BlockCompressedDdsTexture(new BlockCompressedTexture(width, height, mipmapCount, blockWidth, blockHeight, blockSize));

            // Act
            var actual = texture.Pitch;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
