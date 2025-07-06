using FsgImg.Abstractions;
using FsgImg.Factories;
using FsgImg.Pvr.Converters;
using FsgImg.Pvr.Factories;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.CommandLine.Actions
{
    public class ConvertFromPvrAction : AsynchronousCommandLineAction
    {
        private readonly Argument<FileInfo> _inputArgument;
        private readonly Option<FileInfo> _outputOption;

        public ConvertFromPvrAction(Argument<FileInfo> inputArgument, Option<FileInfo> outputOption)
        {
            _inputArgument = inputArgument;
            _outputOption = outputOption;
        }

        public override async Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = default)
        {
            var input = parseResult.GetRequiredValue(_inputArgument);
            var output = parseResult.GetValue(_outputOption) ?? new FileInfo(Path.ChangeExtension(input.FullName, ImgConstants.ImgExtension));

            var readerFactory = new PvrHeaderStreamReaderFactory(new PvrHeaderByteArrayReaderFactory());
            var writerFactory = new ImgHeaderStreamWriterFactory(new ImgHeaderByteArrayWriterFactory());
            var converterFactory = new PvrToImgStreamConverterFactory(new PvrHeaderToImgHeaderConverter(new ImgHeaderFactory()),
                                                                      readerFactory,
                                                                      writerFactory);

            using (var inputStream = input.OpenRead())
            using (var outputStream = output.Create())
            using (var converter = converterFactory.Create(inputStream, outputStream, true))
            {
                await converter.ConvertFromAsync(cancellationToken);
            }

            return 0;
        }
    }
}
