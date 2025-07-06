using FsgImg.CommandLine.Actions;
using System.CommandLine;
using System.IO;

namespace FsgImg.CommandLine.Commands
{
    public class ConvertToPvrCommand : Command
    {
        public ConvertToPvrCommand() : base("convert-to-pvr")
        {
            var inputArgument = new Argument<FileInfo>("input");

            var outputOption = new Option<FileInfo>("--output", "-o");

            Action = new ConvertToPvrAction(inputArgument, outputOption);
            Arguments.Add(inputArgument);
            Options.Add(outputOption);
        }
    }
}
