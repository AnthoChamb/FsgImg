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

            rootCommand.Subcommands.Add(new ConvertFromDdsCommand());
            rootCommand.Subcommands.Add(new ConvertFromPvrCommand());
            rootCommand.Subcommands.Add(new ConvertToDdsCommand());
            rootCommand.Subcommands.Add(new ConvertToPvrCommand());

            await rootCommand.Parse(args).InvokeAsync();
        }
    }
}
