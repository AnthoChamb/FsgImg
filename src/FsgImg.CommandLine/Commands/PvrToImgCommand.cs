using FsgImg.CommandLine.Actions;
using System.CommandLine;
using System.IO;

namespace FsgImg.CommandLine.Commands
{
    public class PvrToImgCommand : Command
    {
        public PvrToImgCommand() : base("pvr-to-img")
        {
            var inputArgument = new Argument<FileInfo>("input");

            var outputOption = new Option<FileInfo>("--output", "-o");

            Action = new PvrToImgAction(inputArgument, outputOption);
            Arguments.Add(inputArgument);
            Options.Add(outputOption);
        }
    }
}
