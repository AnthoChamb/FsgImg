using FsgImg.Pvr.Abstractions;
using FsgImg.Pvr.Factories;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.CommandLine.Actions
{
    public class ImgToPvrAction : AsynchronousCommandLineAction
    {
        private readonly Argument<FileInfo> _inputArgument;
        private readonly Option<FileInfo> _outputOption;

        public ImgToPvrAction(Argument<FileInfo> inputArgument, Option<FileInfo> outputOption)
        {
            _inputArgument = inputArgument;
            _outputOption = outputOption;
        }

        public override async Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = default)
        {
            var input = parseResult.GetRequiredValue(_inputArgument);
            var output = parseResult.GetValue(_outputOption) ?? new FileInfo(Path.ChangeExtension(input.FullName, PvrConstants.PvrExtension));

            var converterFactory = new ImgToPvrStreamConverterFactory();

            using (var inputStream = input.OpenRead())
            using (var outputStream = output.Create())
            using (var converter = converterFactory.Create(inputStream, outputStream, true))
            {
                await converter.ConvertAsync(cancellationToken);
            }

            return 0;
        }
    }
}
