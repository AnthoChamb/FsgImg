using FsgImg.Dds.Abstractions.Enums;

namespace FsgImg.Dds.Abstractions.Options
{
    public class ConvertFromOptions
    {
        public DdsImgGame Game { get; set; } = DdsImgGame.ConsoleGhl;
        public DdsImgPlatform Platform { get; set; }
    }
}
