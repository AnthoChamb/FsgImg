using FsgImg.CommandLine.Commands;
using System.CommandLine;
using System.Threading.Tasks;

namespace FsgImg.CommandLine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var rootCommand = new RootCommand();

            rootCommand.Subcommands.Add(new DdsToImgCommand());
            rootCommand.Subcommands.Add(new PvrToImgCommand());
            rootCommand.Subcommands.Add(new ImgToDdsCommand());
            rootCommand.Subcommands.Add(new ImgToPvrCommand());

            await rootCommand.Parse(args).InvokeAsync();
        }
    }
}
