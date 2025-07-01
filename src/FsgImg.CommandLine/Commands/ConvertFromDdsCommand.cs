using FsgImg.CommandLine.Actions;
using FsgImg.Dds.Abstractions.Enums;
using System.CommandLine;
using System.IO;

namespace FsgImg.CommandLine.Commands
{
    public class ConvertFromDdsCommand : Command
    {
        public ConvertFromDdsCommand() : base("convert-from-dds")
        {
            var inputArgument = new Argument<FileInfo>("input");

            var outputOption = new Option<FileInfo>("--output", "-o");

            var gameOption = new Option<DdsImgGame>("--game", "-g")
            {
                DefaultValueFactory = _ => DdsImgGame.ConsoleGhl
            };

            var platformOption = new Option<DdsImgPlatform>("--platform", "-p");

            Action = new ConvertFromDdsAction(inputArgument, outputOption, gameOption, platformOption);
            Arguments.Add(inputArgument);
            Options.Add(outputOption);
            Options.Add(gameOption);
            Options.Add(platformOption);
        }
    }
}
