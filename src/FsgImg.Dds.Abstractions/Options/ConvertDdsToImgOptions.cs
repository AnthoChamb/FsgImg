using FsgImg.Dds.Abstractions.Enums;

namespace FsgImg.Dds.Abstractions.Options
{
    public class ConvertDdsToImgOptions
    {
        public DdsImgGame Game { get; set; } = DdsImgGame.ConsoleGhl;
        public DdsImgPlatform Platform { get; set; }
    }
}
