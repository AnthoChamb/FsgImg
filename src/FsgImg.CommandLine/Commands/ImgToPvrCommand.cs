using FsgImg.CommandLine.Actions;
using System.CommandLine;
using System.IO;

namespace FsgImg.CommandLine.Commands
{
    public class ImgToPvrCommand : Command
    {
        public ImgToPvrCommand() : base("img-to-pvr")
        {
            var inputArgument = new Argument<FileInfo>("input");

            var outputOption = new Option<FileInfo>("--output", "-o");

            Action = new ImgToPvrAction(inputArgument, outputOption);
            Arguments.Add(inputArgument);
            Options.Add(outputOption);
        }
    }
}
