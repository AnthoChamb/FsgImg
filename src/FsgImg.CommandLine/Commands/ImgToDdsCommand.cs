using FsgImg.CommandLine.Actions;
using FsgImg.Dds.Abstractions.Enums;
using System.CommandLine;
using System.IO;

namespace FsgImg.CommandLine.Commands
{
    public class ImgToDdsCommand : Command
    {
        public ImgToDdsCommand() : base("img-to-dds")
        {
            var inputArgument = new Argument<FileInfo>("input");

            var outputOption = new Option<FileInfo>("--output", "-o");

            var platformOption = new Option<DdsImgPlatform?>("--platform", "-p");

            Action = new ImgToDdsAction(inputArgument, outputOption, platformOption);
            Arguments.Add(inputArgument);
            Options.Add(outputOption);
            Options.Add(platformOption);
        }
    }
}
