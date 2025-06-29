using FsgImg.Abstractions.Enums;

namespace FsgImg.Abstractions.Exceptions
{
    public class InvalidImgTextureFormatException : FsgImgException
    {
        public ImgTextureFormat TextureFormat { get; }

        public InvalidImgTextureFormatException(ImgTextureFormat textureFormat)
        {
            TextureFormat = textureFormat;
        }

        public override string Message
        {
            get
            {
                // TODO: Return resource string
                return string.Empty;
            }
        }

        public static void Throw(ImgTextureFormat textureFormat)
        {
            throw new InvalidImgTextureFormatException(textureFormat);
        }

        public static T Throw<T>(ImgTextureFormat textureFormat)
        {
            throw new InvalidImgTextureFormatException(textureFormat);
        }
    }
}
