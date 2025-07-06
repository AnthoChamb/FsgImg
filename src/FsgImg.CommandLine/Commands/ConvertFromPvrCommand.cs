using FsgImg.CommandLine.Actions;
using System.CommandLine;
using System.IO;

namespace FsgImg.CommandLine.Commands
{
    public class ConvertFromPvrCommand : Command
    {
        public ConvertFromPvrCommand() : base("convert-from-pvr")
        {
            var inputArgument = new Argument<FileInfo>("input");

            var outputOption = new Option<FileInfo>("--output", "-o");

            Action = new ConvertFromPvrAction(inputArgument, outputOption);
            Arguments.Add(inputArgument);
            Options.Add(outputOption);
        }
    }
}
